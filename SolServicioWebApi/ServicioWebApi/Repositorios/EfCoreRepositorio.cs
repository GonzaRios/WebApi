using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Interfaces;
using System.Text.RegularExpressions;

namespace ServicioWebApi.Repositorios
{
    public abstract class EfCoreRepositorio<TEntity, TContext>: IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _contexto;
        public EfCoreRepositorio(TContext contexto) 
        {
            _contexto = contexto;  
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity); // agrego a memoria
            await _contexto.SaveChangesAsync(); // persisto en la bd
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entidadBorrar = await _contexto.Set<TEntity>().FindAsync(id);
            if (entidadBorrar == null)
            {
                return entidadBorrar;
            }
            else
            {
                _contexto.Set<TEntity>().Remove(entidadBorrar);
                await _contexto.SaveChangesAsync();
                return entidadBorrar;
            }
        }

        public async Task<TEntity> Get(int id)
        {
            var entidadRetornar= await _contexto.Set<TEntity>().FindAsync(id);
            if (entidadRetornar == null)
            {
                return entidadRetornar;
            }
            return entidadRetornar;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var lista = await _contexto.Set<TEntity>().ToListAsync();
            return lista;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return entity; 
        }
    }
}
