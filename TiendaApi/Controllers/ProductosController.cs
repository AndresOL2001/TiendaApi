using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaApi.DTOs.Product;
using TiendaApi.Entity;
using TiendaApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper automapper;

        public ProductosController(ApplicationDbContext context,IMapper automapper)
        {
            this.context = context;
            this.automapper = automapper;
        }


        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>>  Get()
        {
            var productos = await context.productos
                .Include(x => x.categoriaProducto)
                .ThenInclude(x => x.categoria)
                .ToListAsync();

            var dtos = automapper.Map<List<ProductoDTO>>(productos);

            return dtos;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}",Name ="getProducto")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var existeProd = await context.productos
                .Include(x => x.categoriaProducto)
                .ThenInclude(x=>x.categoria)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existeProd == null)
            {
                return NotFound();
            }

           return automapper.Map<ProductoDTO>(existeProd);

        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreateDTO productoDTO)
        {
            if(productoDTO == null)
            {
                return BadRequest();
            }   
                                           //Destiny         //Source
            var entidad = automapper.Map<Producto>(productoDTO);

            context.Add(entidad);
            await context.SaveChangesAsync();
 
            var dtoProducto = automapper.Map<ProductoDTO>(entidad);

            return CreatedAtRoute("getProducto", new { id = dtoProducto.Id },dtoProducto);

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductCreateDTO productoDTO)
        {
            var existeProd = await context.productos.AnyAsync(x => x.Id == id);

            if (!existeProd)
            {
                return NotFound();
            }

            var entidad = automapper.Map<Producto>(productoDTO);

            entidad.Id = id;

            context.Update(entidad);

            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.productos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Producto() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
