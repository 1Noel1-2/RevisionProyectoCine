namespace Proyecto_Cine.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Categoria { get; set; } = "";
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
    }
}
