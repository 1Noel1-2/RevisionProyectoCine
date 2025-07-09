using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Cine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Cine.Pages.Admin
{
    public class ModificarAgregarSalasAdminModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public ModificarAgregarSalasAdminModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sala Sala { get; set; } = new();

        public List<Sucursale> Sucursales { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            Sucursales = _context.Sucursales.ToList();

            if (id != null)
            {
                Sala = _context.Salas.FirstOrDefault(s => s.Id == id)!;
                if (Sala == null) return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (Sala.Id == 0)
            {
                Sala.Estado = "Activa"; // Valor por defecto al crear nueva sala
                _context.Salas.Add(Sala);
            }
            else
            {
                var salaExistente = _context.Salas.FirstOrDefault(s => s.Id == Sala.Id);
                if (salaExistente == null) return NotFound();

                // Actualizar propiedades
                salaExistente.Nombre = Sala.Nombre;
                salaExistente.Capacidad = Sala.Capacidad;
                salaExistente.Tipo = Sala.Tipo;
                salaExistente.IdSucursal = Sala.IdSucursal;

                _context.Salas.Update(salaExistente);
            }

            _context.SaveChanges();
            return RedirectToPage("/Admin/SalasAdmin");
        }
    }
}