using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Entity
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public double PrecioUnitario { get; set; }

        public int cantidad { get; set; }

        public double descuento { get; set; }

        public int ProductoId { get; set; }
        public Producto producto { get; set; }

        public int OrdenId { get; set; }

        public Orden orden { get; set; }
       

    }
}
