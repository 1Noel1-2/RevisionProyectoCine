using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin
{
    public class FuncionesAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public FuncionesAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        public List<Pelicula> Peliculas { get; set; } = new();
        public List<Sala> Salas { get; set; } = new();

        public Dictionary<string, List<Funcione>> FuncionesActivas { get; set; } = new();
        public Dictionary<string, List<Funcione>> FuncionesInactivas { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? FiltroPeliculaId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? FiltroSalaId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? FiltroFecha { get; set; }

        public void OnGet()
        {
            Peliculas = _context.Peliculas.ToList();
            Salas = _context.Salas.ToList();

            var query = _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .AsQueryable();

            if (FiltroPeliculaId.HasValue)
                query = query.Where(f => f.PeliculaId == FiltroPeliculaId);

            if (FiltroSalaId.HasValue)
                query = query.Where(f => f.SalaId == FiltroSalaId);

            if (FiltroFecha.HasValue)
                query = query.Where(f => f.Fecha == FiltroFecha);

            // Funciones activas
            FuncionesActivas = query
                .Where(f => f.Estado == "Activa")
                .ToList()
                .GroupBy(f => f.Pelicula.Titulo)
                .ToDictionary(g => g.Key!, g => g.ToList());

            // Funciones inactivas
            FuncionesInactivas = query
                .Where(f => f.Estado == "Inactiva")
                .ToList()
                .GroupBy(f => f.Pelicula.Titulo)
                .ToDictionary(g => g.Key!, g => g.ToList());
        }

        public IActionResult OnPostEliminar(int id)
        {
            var funcion = _context.Funciones.Find(id);
            if (funcion != null)
            {
                funcion.Estado = "Inactiva"; // ✅ Desactiva en lugar de borrar
                _context.Funciones.Update(funcion);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostActivar(int id)
        {
            var funcion = _context.Funciones.Find(id);
            if (funcion != null)
            {
                funcion.Estado = "Activa";
                _context.Funciones.Update(funcion);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}