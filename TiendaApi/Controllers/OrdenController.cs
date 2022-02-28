using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaApi.DTOs;
using TiendaApi.Entity;

namespace TiendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper automapper;

        public OrdenController(ApplicationDbContext context, IMapper automapper)
        {
            this.context = context;
            this.automapper = automapper;
        }
       

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleOrdenCreacionDTO detalleOrden)
        {
            if (detalleOrden == null)
            {
                return BadRequest();
            }
            //Destiny         //Source
            var entidad = automapper.Map<DetalleOrden>(detalleOrden);

            context.Add(entidad);
            await context.SaveChangesAsync();


            return Ok(entidad);

        }

       
    }

}
