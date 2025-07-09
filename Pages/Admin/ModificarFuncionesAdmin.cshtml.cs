using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cine.Pages.Admin
{
    public class ModificarFuncionesAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public ModificarFuncionesAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcione Funcion { get; set; } = new();

        public List<Pelicula> Peliculas { get; set; } = new();
        public List<Sala> Salas { get; set; } = new();

        public void OnGet(int? id)
        {
            Peliculas = _context.Peliculas.ToList();
            Salas = _context.Salas.ToList();

            if (id.HasValue)
            {
                Funcion = _context.Funciones
                    .AsNoTracking()
                    .FirstOrDefault(f => f.Id == id) ?? new Funcione();
            }
        }

        public IActionResult OnPost()
        {
            Peliculas = _context.Peliculas.ToList();
            Salas = _context.Salas.ToList();

            if (!ModelState.IsValid)
                return Page();

            bool hayConflicto = _context.Funciones.Any(f =>
                f.Id != Funcion.Id &&
                f.SalaId == Funcion.SalaId &&
                f.Fecha == Funcion.Fecha &&
                (
                    (Funcion.HoraInicio >= f.HoraInicio && Funcion.HoraInicio < f.HoraFin) ||
                    (Funcion.HoraFin > f.HoraInicio && Funcion.HoraFin <= f.HoraFin) ||
                    (Funcion.HoraInicio <= f.HoraInicio && Funcion.HoraFin >= f.HoraFin)
                )
            );

            if (hayConflicto)
            {
                ModelState.AddModelError(string.Empty, "❗ Ya existe una función que se traslapa en esa sala, fecha y horario.");
                return Page();
            }

            if (Funcion.Id > 0)
            {
                _context.Funciones.Update(Funcion);
            }
            else
            {
                Funcion.Estado = "Activa"; // ✅ estado por defecto al crear
                _context.Funciones.Add(Funcion);
            }

            _context.SaveChanges();

            TempData["MensajeExito"] = "✅ Función guardada exitosamente.";
            return RedirectToPage("/Admin/FuncionesAdmin", new { FiltroPeliculaId = (int?)null, FiltroSalaId = (int?)null, FiltroFecha = (DateOnly?)null });
        }
    }
}