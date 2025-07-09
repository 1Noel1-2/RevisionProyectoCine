using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages
{
    [Authorize(Roles = "Admin")]
    public class PanelAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public PanelAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        public int PeliculasActivas { get; set; }
        public int SalasDisponibles { get; set; }
        public int EstrenosProximos { get; set; }
        public int BoletosVendidosSemana { get; set; }
        public List<string> Notificaciones { get; set; } = new();

        public async Task OnGetAsync()
        {
            PeliculasActivas = await _context.Peliculas.CountAsync(p => p.Activa == true);

            SalasDisponibles = await _context.Salas.CountAsync();

            EstrenosProximos = await _context.Funciones
                .Where(f => f.Fecha.HasValue &&
                            f.Fecha.Value >= DateOnly.FromDateTime(DateTime.Today) &&
                            f.Fecha.Value <= DateOnly.FromDateTime(DateTime.Today.AddDays(14)))
                .Select(f => f.PeliculaId)
                .Distinct()
                .CountAsync();

            BoletosVendidosSemana = await _context.Entradas
                .Where(e => e.Reserva.FechaReserva >= DateTime.Today.AddDays(-7))
                .CountAsync();

            if (PeliculasActivas < 5)
                Notificaciones.Add("Hay menos de 5 películas activas en cartelera.");

            if (EstrenosProximos == 0)
                Notificaciones.Add("No hay estrenos programados para las próximas 2 semanas.");
        }
    }
}
