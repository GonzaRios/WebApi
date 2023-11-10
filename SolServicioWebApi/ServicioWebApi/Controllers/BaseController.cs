using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ServicioWebApi.Data;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Models;
using ServicioWebApi.Repositorios;


namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntidad, TRepositorio> : ControllerBase
        where TEntidad : class, IEntity
        where TRepositorio : IRepository<TEntidad>
    {
        private readonly TRepositorio _Repositorio;
        public BaseController(TRepositorio repositorio)
        {
            _Repositorio = repositorio;
        }
        //CRUD
        [HttpGet]
        public async Task<ActionResult<List<TEntidad>>> TraerTodos()
        {
            var lista = await _Repositorio.GetAll();
            return lista;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntidad>> TraerUno(int id)
        {
            var entidad = await _Repositorio.Get(id);
            return entidad;
        }
        [HttpPost]
        public async Task<ActionResult<TEntidad>> Agregar(TEntidad entidad)
        {
            await _Repositorio.Add(entidad);
            return Ok(entidad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TEntidad>> Actualizar(int id, TEntidad entidad)
        {
            if (id != entidad.ID)
            {
                return BadRequest()
;           }
            await _Repositorio.Update(entidad);
            return Ok(entidad);
        }
        [HttpDelete]
        public async Task<ActionResult<TEntidad>> Borrar(int id)
        {
            var entidadBorrar = await _Repositorio.Delete(id);
            return entidadBorrar;
        }
    }

}
