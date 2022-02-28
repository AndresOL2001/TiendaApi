using TiendaApi.DTOs.Categoria;
using TiendaApi.Entity;

namespace TiendaApi.DTOs.Product
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string ProductoNombre { get; set; }

        public int CantidadEnStock { get; set; }

        public double Precio { get; set; }
        public string? Imagen { get; set; }

        public List<CategoriaDTO> categorias { get; set; }

    }
}
