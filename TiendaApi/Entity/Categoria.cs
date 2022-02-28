using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Entity
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string? Imagen { get; set; }

        public List<CategoriaProducto> categoriaProducto { get; set; }

    }
}
