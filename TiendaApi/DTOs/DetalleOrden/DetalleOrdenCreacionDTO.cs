namespace TiendaApi.DTOs
{
    public class DetalleOrdenCreacionDTO
    {
        public double PrecioUnitario { get; set; }

        public int cantidad { get; set; }

        public double descuento { get; set; }

        public int ProductoId { get; set; }
    }
}
