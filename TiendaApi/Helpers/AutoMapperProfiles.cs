using AutoMapper;
using TiendaApi.DTOs;
using TiendaApi.DTOs.Categoria;
using TiendaApi.DTOs.Product;
using TiendaApi.Entity;

namespace TiendaApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(x => x.categorias, options => options.MapFrom(MapCategoriaProductos));

            CreateMap<ProductCreateDTO, Producto>()
                .ForMember(x=>x.categoriaProducto,options => options.MapFrom(MapCategoriaProducto));

            //Orden
            CreateMap<DetalleOrdenCreacionDTO, DetalleOrden>();
            //Categoria
            CreateMap<CategoriaCreacionDTO, Categoria>().ReverseMap();
        }

        private List<CategoriaProducto> MapCategoriaProducto(ProductCreateDTO productoCreacionDTO, Producto producto)
        {
            var resultado = new List<CategoriaProducto>();
            if (productoCreacionDTO.categoriasId == null)
            {
                return resultado;
            }

            foreach (var id in productoCreacionDTO.categoriasId)
            {
                resultado.Add(new CategoriaProducto() { categoriaId = id });
            }

            return resultado;
        }

        private List<CategoriaDTO> MapCategoriaProductos(Producto producto, ProductoDTO productoDTO)
        {
            var resultado = new List<CategoriaDTO>();

            if (producto.categoriaProducto == null)
            {
                return resultado;
            }

            foreach (var categoriaDelProducto in producto.categoriaProducto)
            {
                resultado.Add(new CategoriaDTO() {Id=categoriaDelProducto.categoriaId, Nombre=categoriaDelProducto.categoria.Nombre });
            }

            return resultado;
        }

    }

  
}
