using System.ComponentModel.DataAnnotations;

namespace TiendaApi.DTOs.Categoria
{
    public class CategoriaCreacionDTO
    {

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string? Imagen { get; set; }
    }
}
