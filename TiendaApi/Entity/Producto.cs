using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Entity
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductoNombre { get; set; }

        public int CantidadEnStock { get; set; }

        public double Precio { get; set; }

        public string? Imagen { get; set; }

        public List<CategoriaProducto> categoriaProducto { get; set; }

    }
}
