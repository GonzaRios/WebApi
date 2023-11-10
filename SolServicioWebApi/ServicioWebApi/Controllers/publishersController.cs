using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Data;
using ServicioWebApi.Models;

namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class publishersController : ControllerBase
    {
        private readonly pubsContext? _contexto;
        public publishersController(pubsContext contexto)
        {
            _contexto = contexto;
        }
        //CRUD
        [HttpGet]
        public async Task<ActionResult<List<publisher>>> TraerTodos()
        {
            var listaPublishers = (from sh in _contexto.publishers
                                   select sh).ToListAsync();
            return await listaPublishers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<publisher>> TraerUno(string id)
        {
            var publisher = await _contexto.publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound(); // codigo 404
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(publisher publisher)
        {
            _contexto.publishers.Add(publisher); //agrega a la coleccion
            await _contexto.SaveChangesAsync(); // aplica el insert
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(string id, publisher publisher)
        {
            if (id != publisher.pub_id)
            {
                return BadRequest();
            }
            _contexto.publishers.Update(publisher);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(string id)
        {
            var pubBorrar = await _contexto.publishers.FindAsync(id);
            if (pubBorrar == null)
            {
                return NotFound();
            }
            _contexto.publishers.Remove(pubBorrar);
            await _contexto.SaveChangesAsync();
            return Ok();
        }
    }
}
