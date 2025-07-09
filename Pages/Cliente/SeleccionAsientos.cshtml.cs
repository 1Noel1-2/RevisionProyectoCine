using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Cine.Pages.Cliente
{
    public class SeleccionAsientosModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public SeleccionAsientosModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        // Recibimos estos valores via query string desde Funciones.cshtml
        [BindProperty(SupportsGet = true)]
        public int idFuncion { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BoletosDescripcionInput { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public decimal TotalPrecio { get; set; }

        // Datos de la función/película/sala
        public Funcione? Funcion { get; set; }
        public Pelicula? Pelicula { get; set; }
        public string NombreSucursal { get; set; } = "";
        public string NombreSala     { get; set; } = "";
        public string FechaFormateada => Funcion?.Fecha?.ToString("dd/MM/yyyy") ?? "";
        public string HoraFormateada  => Funcion?.HoraInicio?.ToString("HH:mm") ?? "";

        // Matriz de asientos para la UI
        public Dictionary<string, List<AsientoVista>> MatrizAsientos { get; set; }
            = new Dictionary<string, List<AsientoVista>>();

        // Asientos que selecciona el usuario
        [BindProperty]
        public List<int> AsientosSeleccionados { get; set; } = new List<int>();

        // JSON con tipos y cantidades de boletos (desde JS)
        [BindProperty]
        public string BoletosJson { get; set; } = "";

        // DTO para renderizar cada asiento
        public class AsientoVista
        {
            public int Id        { get; set; }
            public string Fila   { get; set; } = "";
            public int Numero    { get; set; }
            public bool Disponible { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await CargarInformacion();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Validación: al menos un asiento
            if (AsientosSeleccionados == null || !AsientosSeleccionados.Any())
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar al menos un asiento.");
                await CargarInformacion();
                return Page();
            }

            // 2. Redirigir a ResumenPago enviando todo por query string
            return RedirectToPage(
                "/Cliente/ResumenPago",
                new
                {
                    idFuncion,
                    BoletosDescripcionInput,
                    AsientosSeleccionados = string.Join(",", AsientosSeleccionados),
                    TotalPrecio
                });
        }

        private async Task CargarInformacion()
        {
            // Traer datos de la función junto a Película, Sala y Sucursal
            Funcion = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .Include(f => f.Sucursal)
                .FirstOrDefaultAsync(f => f.Id == idFuncion);

            if (Funcion == null)
                return;

            Pelicula        = Funcion.Pelicula;
            NombreSucursal = Funcion.Sucursal?.Nombre ?? "Desconocido";
            NombreSala      = Funcion.Sala?.Nombre     ?? "Desconocido";

            // Cargar asientos de la sala y su disponibilidad en la función
            var asientosSala = await _context.Asientos
                .Where(a => a.SalaId == Funcion.SalaId)
                .ToListAsync();

            var asientosFuncion = await _context.AsientosFuncions
                .Where(af => af.FuncionId == idFuncion)
                .ToListAsync();

            var mapaDisponibilidad = asientosFuncion
                .ToDictionary(af => af.AsientoId, af => af.Disponible ?? true);

            MatrizAsientos.Clear();

            foreach (var asiento in asientosSala)
            {
                var filaKey = asiento.Fila ?? "?";
                if (!MatrizAsientos.ContainsKey(filaKey))
                    MatrizAsientos[filaKey] = new List<AsientoVista>();

                MatrizAsientos[filaKey].Add(new AsientoVista
                {
                    Id         = asiento.Id,
                    Fila       = filaKey,
                    Numero     = asiento.Numero ?? 0,
                    Disponible = mapaDisponibilidad.TryGetValue(asiento.Id, out var disp)
                                  ? disp
                                  : true
                });
            }
        }
    }
}
