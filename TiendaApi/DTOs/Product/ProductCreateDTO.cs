using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TiendaApi.Helpers;

namespace TiendaApi.DTOs.Product
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string ProductoNombre { get; set; }

        public int CantidadEnStock { get; set; }

        public double Precio { get; set; }

        public string? Imagen { get; set; }

        [ModelBinder(BinderType =typeof(ModelBinder<List<int>>))]
        public List<int> categoriasId { get; set; }
    }

}
