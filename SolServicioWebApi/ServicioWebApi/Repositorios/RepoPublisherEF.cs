using ServicioWebApi.Models;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ServicioWebApi.Repositorios
{
    public class RepoPublisherEF : IPublisher
    {
        private readonly pubsContext _contexto;
        public RepoPublisherEF(pubsContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<publisher> Actualizar(publisher entidad)
        {
            _contexto.publishers.Update(entidad);
            await _contexto.SaveChangesAsync();
            return entidad; 
        }

        public async Task<publisher> Agregar(publisher entidad)
        {
            _contexto.publishers.Add(entidad);
            await _contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<publisher> Borrar(string id)
        {
            var pub = await _contexto.publishers.FindAsync(id);
            _contexto.publishers.Remove(pub);
            await _contexto.SaveChangesAsync();
            return pub;
        }

        public async Task<List<publisher>> TraerTodos()
        {
            var publishers = from pb in _contexto.publishers
                             select pb;
            return await publishers.ToListAsync();
        }

        public async Task<publisher> TraerUno(string id)
        {
            var pub = await _contexto.publishers.FindAsync(id);
            return pub;
        }
    }
}
