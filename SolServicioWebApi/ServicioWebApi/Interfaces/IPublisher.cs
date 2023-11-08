using ServicioWebApi.Models;

namespace ServicioWebApi.Interfaces
{
    public interface IPublisher
    {
        Task<List<publisher>> TraerTodos();
        Task<publisher> TraerUno(string id);
        Task<publisher> Agregar(publisher entidad);
        Task<publisher> Actualizar(publisher entidad);

        Task<publisher> Borrar(string id);

    }
}
