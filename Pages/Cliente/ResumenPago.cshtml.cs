using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;
using System.Globalization;

namespace Proyecto_Cine.Pages.Cliente
{
    public class ResumenPagoModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public ResumenPagoModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int idFuncion { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BoletosDescripcionInput { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string AsientosSeleccionados { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public decimal TotalPrecio { get; set; }

        public Funcione? Funcion { get; set; }
        public Pelicula? Pelicula { get; set; }
        public string NombreSucursal { get; set; } = "";
        public string NombreSala     { get; set; } = "";
        public string FechaFormateada => Funcion?.Fecha?.ToString("dd/MM/yyyy") ?? "";
        public string HoraFormateada  => Funcion?.HoraInicio?.ToString("HH:mm") ?? "";

        public string AsientosSeleccionadosTexto { get; set; } = "";

        public Dictionary<string, (int Cantidad, decimal PrecioUnitario, decimal Subtotal)> DesgloseBoletos 
            { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            await CargarInformacion();

            // Convertir asientos a texto legible
            if (!string.IsNullOrEmpty(AsientosSeleccionados))
                AsientosSeleccionadosTexto = await ObtenerTextoAsientos(AsientosSeleccionados);

            await CalcularDesgloseBoletos();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await CargarInformacion();

            if (string.IsNullOrWhiteSpace(AsientosSeleccionados) ||
                string.IsNullOrWhiteSpace(BoletosDescripcionInput) ||
                TotalPrecio <= 0)
            {
                ModelState.AddModelError(string.Empty, "Faltan datos o el total es inválido.");
                return Page();
            }

            // Marcar asientos como ocupados
            var ids = AsientosSeleccionados
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s, out var i) ? i : 0)
                .Where(i => i > 0);

            foreach (var id in ids)
            {
                var af = await _context.AsientosFuncions
                    .FirstOrDefaultAsync(x => x.FuncionId == idFuncion && x.AsientoId == id);
                if (af != null) af.Disponible = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Cliente/Confirmacion");
        }

        private async Task CargarInformacion()
        {
            Funcion = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .Include(f => f.Sucursal)
                .FirstOrDefaultAsync(f => f.Id == idFuncion);

            if (Funcion != null)
            {
                Pelicula        = Funcion.Pelicula;
                NombreSucursal = Funcion.Sucursal?.Nombre ?? "Desconocido";
                NombreSala      = Funcion.Sala?.Nombre     ?? "Desconocido";
            }
        }

        private async Task<string> ObtenerTextoAsientos(string idsCsv)
        {
            var ids = idsCsv
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s, out var i) ? i : 0)
                .Where(i => i > 0)
                .ToList();

            var asientos = await _context.Asientos
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();

            var codigos = asientos
                .OrderBy(a => a.Fila)
                .ThenBy(a => a.Numero)
                .Select(a => $"{a.Fila}{a.Numero}");

            return string.Join(", ", codigos);
        }

        private async Task CalcularDesgloseBoletos()
        {
            if (Funcion == null || string.IsNullOrEmpty(BoletosDescripcionInput))
                return;

            var precios = await _context.PreciosFuncions
                .Where(p => p.FuncionId == idFuncion)
                .ToDictionaryAsync(p => p.TipoBoletoId, p => p.Precio ?? 0m);

            var tipoMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "Adulto", 1 },
                { "Niño",   2 },
                { "Senior", 3 }
            };

            var entradas = BoletosDescripcionInput
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(part =>
                {
                    var pieces = part.Trim().Split(' ');
                    return (tipo: pieces[1].Replace("(s)", "").Trim(),
                            cantidad: int.TryParse(pieces[0], out var n) ? n : 0);
                });

            DesgloseBoletos.Clear();
            foreach (var (tipo, cantidad) in entradas)
            {
                if (tipoMap.TryGetValue(tipo, out var tipoId) &&
                    precios.TryGetValue(tipoId, out var precio))
                {
                    DesgloseBoletos[tipo] = 
                        (cantidad, precio, precio * cantidad);
                }
            }
        }
    }
}
