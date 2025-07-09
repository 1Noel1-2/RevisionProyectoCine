using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Cine.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_Cine.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SarmiMovieDbContext _context;

        public LoginModel(SarmiMovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        public string MensajeError { get; set; }

        public string HashDebug { get; set; }
        public string HashGuardado { get; set; }
        public bool HashMatch { get; set; }

        public IActionResult OnGet()
        {
            // Si ya está autenticado, redirige según el rol
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToPage("/Admin/PanelAdmin");
                else if (User.IsInRole("Cliente"))
                    return RedirectToPage("/Cliente/Home");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == Email.ToLower());

            if (usuario == null)
            {
                MensajeError = "El correo no está registrado.";
                return Page();
            }

            var hashIngresado = CalcularHash(Password);
            HashDebug = hashIngresado;
            HashGuardado = usuario.ContrasenaHash;
            HashMatch = hashIngresado == usuario.ContrasenaHash;

            if (!HashMatch)
            {
                MensajeError = "Contraseña incorrecta.";
                return Page();
            }

            if (!usuario.Activo.HasValue || !usuario.Activo.Value)
            {
                MensajeError = "Tu cuenta está inactiva.";
                return Page();
            }

            // ✅ Crear claims para el usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre ?? usuario.Email),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // ✅ Guardar la cookie de sesión
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // ✅ Redirigir según el rol
            if (usuario.Rol.ToLower() == "admin")
            {
                return RedirectToPage("/Admin/PanelAdmin");
            }
            else if (usuario.Rol.ToLower() == "cliente")
            {
                return RedirectToPage("/Cliente/Home");
            }
            else
            {
                MensajeError = "Rol de usuario no reconocido.";
                return Page();
            }
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