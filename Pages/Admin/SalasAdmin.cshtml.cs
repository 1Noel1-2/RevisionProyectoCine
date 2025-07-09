using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto_Cine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Cine.Pages.Admin
{
    public class SalasAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public SalasAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        public List<Sala> SalasActivas { get; set; } = new();
        public List<Sala> SalasInactivas { get; set; } = new();

        public void OnGet()
        {
            SalasActivas = _context.Salas
                .Include(s => s.IdSucursalNavigation)
                .Where(s => s.Estado == "Activa")
                .ToList();

            SalasInactivas = _context.Salas
                .Include(s => s.IdSucursalNavigation)
                .Where(s => s.Estado == "Inactiva")
                .ToList();
        }

        public IActionResult OnPostSuspender(int id)
        {
            var sala = _context.Salas.FirstOrDefault(s => s.Id == id);
            if (sala != null)
            {
                sala.Estado = "Inactiva";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostActivar(int id)
        {
            var sala = _context.Salas.FirstOrDefault(s => s.Id == id);
            if (sala != null)
            {
                sala.Estado = "Activa";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}