using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaApi.DTOs.Categoria;
using TiendaApi.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper automapper;

        public CategoriaController(ApplicationDbContext context, IMapper automapper)
        {
            this.context = context;
            this.automapper = automapper;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaCreacionDTO categoriaCreacionDTO)
        {
            if(categoriaCreacionDTO == null)
            {
                return NotFound();
            }                           
            var entidad = automapper.Map<Categoria>(categoriaCreacionDTO);
            context.Add(entidad);

            await context.SaveChangesAsync();


            return Ok(entidad);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
