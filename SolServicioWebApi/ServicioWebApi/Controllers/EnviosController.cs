using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWebApi.Models;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Data;
using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Repositorios;

namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IPublisher _publisher;
        public EnviosController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult<List<publisher>>> GetAll()
        {
            return await _publisher.TraerTodos();
        }
        [HttpPost]
        public async Task<ActionResult<publisher>> Nuevo(publisher publisher)
        {
            return await _publisher.Agregar(publisher);
        }
    }
}
