using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto_Cine.Pages.Admin
{
    public class ConexionPruebaModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public ConexionPruebaModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Mensaje { get; set; }

        public void OnPost()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                Mensaje = "✅ Conexión exitosa a la base de datos.";
            }
            catch (Exception ex)
            {
                Mensaje = $"❌ Error de conexión: {ex.Message}";
            }
        }
    }
}
