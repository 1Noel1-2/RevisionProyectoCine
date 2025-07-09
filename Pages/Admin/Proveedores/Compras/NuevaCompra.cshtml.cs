using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin.Proveedores
{
    public class NuevaCompraModel : PageModel
    {
        public List<Producto> Productos { get; set; } = new();
        public List<Proveedor> Proveedores { get; set; } = new();

        [BindProperty]
        public Compra Compra { get; set; } = new();

        public string Mensaje { get; set; } = "";

        private readonly IConfiguration _configuration;

        public NuevaCompraModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using (var cmdProd = new MySqlCommand("SELECT * FROM productos;", connection))
            using (var reader = cmdProd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Productos.Add(new Producto
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()!
                    });
                }
            }

            using (var cmdProv = new MySqlCommand("SELECT * FROM proveedores;", connection))
            using (var reader = cmdProv.ExecuteReader())
            {
                while (reader.Read())
                {
                    Proveedores.Add(new Proveedor
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()!
                    });
                }
            }
        }

        public IActionResult OnPost()
        {
            if (Compra.Cantidad <= 0)
            {
                Mensaje = "❌ La cantidad debe ser mayor a cero.";
                OnGet();
                return Page();
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertCompraQuery = @"INSERT INTO compras (producto_id, proveedor_id, cantidad, fecha_compra)
                                         VALUES (@producto_id, @proveedor_id, @cantidad, @fecha);";

            using (var cmd = new MySqlCommand(insertCompraQuery, connection))
            {
                cmd.Parameters.AddWithValue("@producto_id", Compra.ProductoId);
                cmd.Parameters.AddWithValue("@proveedor_id", Compra.ProveedorId);
                cmd.Parameters.AddWithValue("@cantidad", Compra.Cantidad);
                cmd.Parameters.AddWithValue("@fecha", Compra.Fecha);
                cmd.ExecuteNonQuery();
            }

            string updateStockQuery = @"UPDATE productos 
                                        SET existencia = existencia + @cantidad 
                                        WHERE id = @producto_id;";

            using (var cmdUpdate = new MySqlCommand(updateStockQuery, connection))
            {
                cmdUpdate.Parameters.AddWithValue("@cantidad", Compra.Cantidad);
                cmdUpdate.Parameters.AddWithValue("@producto_id", Compra.ProductoId);
                cmdUpdate.ExecuteNonQuery();
            }

            Mensaje = "✅ Compra registrada y stock actualizado.";
            OnGet();
            return Page();
        }
    }
}
