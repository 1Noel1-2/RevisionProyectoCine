using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin.Productos
{
    public class InventarioModel : PageModel
    {
        public List<Producto> Productos { get; set; } = new();

        private readonly IConfiguration _configuration;

        public InventarioModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM productos;";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Productos.Add(new Producto
                {
                    Id = reader["id"] is DBNull ? 0 : Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"]?.ToString() ?? "",
                    Marca = reader["marca"]?.ToString() ?? "",
                    Precio = reader["precio"] is DBNull ? 0 : Convert.ToDecimal(reader["precio"]),
                    Existencia = reader["existencia"] is DBNull ? 0 : Convert.ToInt32(reader["existencia"]),
                    Categoria = reader["categoria"]?.ToString() ?? ""
                });
            }
        }
    }
}
