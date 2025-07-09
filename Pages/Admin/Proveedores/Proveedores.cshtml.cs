using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Proyecto_Cine.Models;

namespace Proyecto_Cine.Pages.Admin.Proveedores
{
    public class ProveedoresModel : PageModel
    {
        public List<Proveedor> Proveedores { get; set; } = new();
        public List<CompraExtendida> Compras { get; set; } = new();

        private readonly IConfiguration _configuration;

        public ProveedoresModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            // Proveedores
            string proveedorQuery = "SELECT * FROM proveedores;";
            using (var cmd = new MySqlCommand(proveedorQuery, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Proveedores.Add(new Proveedor
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        RazonSocial = reader.GetString("razon_social"),
                        RFC = reader.GetString("rfc"),
                        Domicilio = reader.GetString("domicilio"),
                        Telefono = reader.GetString("telefono")
                    });
                }
            }

            // Compras con JOIN para nombres
            string comprasQuery = @"
                SELECT c.id, c.cantidad, c.fecha_compra, p.nombre AS nombre_proveedor, pr.nombre AS nombre_producto
                FROM compras c
                JOIN proveedores p ON c.proveedor_id = p.id
                JOIN productos pr ON c.producto_id = pr.id;
            ";

            using (var cmd = new MySqlCommand(comprasQuery, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Compras.Add(new CompraExtendida
                    {
                        Cantidad = reader.GetInt32("cantidad"),
                        Fecha = reader.GetDateTime("fecha_compra"), // corregido aquí
                        NombreProveedor = reader.GetString("nombre_proveedor"),
                        NombreProducto = reader.GetString("nombre_producto")
                    });
                }
            }
        }

        public class CompraExtendida
        {
            public string NombreProveedor { get; set; } = "";
            public string NombreProducto { get; set; } = "";
            public int Cantidad { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}
