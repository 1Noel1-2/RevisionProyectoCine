using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin.Proveedores
{
    public class AltaModel : PageModel
    {
        [BindProperty]
        public Proveedor Proveedor { get; set; } = new();

        public string Mensaje { get; set; } = "";

        private readonly IConfiguration _configuration;

        public AltaModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnPost()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = @"INSERT INTO proveedores (nombre, razon_social, rfc, domicilio, telefono)
                             VALUES (@nombre, @razon_social, @rfc, @domicilio, @telefono);";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", Proveedor.Nombre);
            cmd.Parameters.AddWithValue("@razon_social", Proveedor.RazonSocial);
            cmd.Parameters.AddWithValue("@rfc", Proveedor.RFC);
            cmd.Parameters.AddWithValue("@domicilio", Proveedor.Domicilio);
            cmd.Parameters.AddWithValue("@telefono", Proveedor.Telefono);

            cmd.ExecuteNonQuery();
            Mensaje = "✅ Proveedor guardado correctamente.";
        }
    }
}

