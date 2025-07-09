using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin
{
    public class ConsultarFuncionesAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public ConsultarFuncionesAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        public List<Funcione> Funciones { get; set; } = new();

        public void OnGet()
        {
            Funciones = _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .ToList();
        }
    }
}
