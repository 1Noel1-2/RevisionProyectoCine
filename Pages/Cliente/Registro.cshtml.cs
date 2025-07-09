using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Cine.Models;
using Proyecto_Cine.Models.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_Cine.Pages
{
    public class RegistroModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public RegistroModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegistroViewModel Datos { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existe = _context.Usuarios.Any(u => u.Email == Datos.Email);
            if (existe)
            {
                ModelState.AddModelError(string.Empty, "Ese correo ya está registrado.");
                return Page();
            }

            var nuevo = new Usuario
            {
                Nombre = Datos.Nombre,
                Apellido = Datos.Apellido,
                Email = Datos.Email.ToLower(),
                ContrasenaHash = CalcularHash(Datos.Contrasena),
                Rol = "Cliente",
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            _context.Usuarios.Add(nuevo);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login");
        }

        private string CalcularHash(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
