namespace Proyecto_Cine.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
