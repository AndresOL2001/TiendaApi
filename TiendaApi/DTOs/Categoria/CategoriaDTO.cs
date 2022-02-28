using System.ComponentModel.DataAnnotations;

namespace TiendaApi.DTOs.Categoria
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string? Imagen { get; set; }
    }
}
