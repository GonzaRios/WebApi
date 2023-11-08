using ServicioWebApi.Models;
using ServicioWebApi.Data;


namespace ServicioWebApi.Repositorios
{
    public class EfCorePublisherRepositorio: EfCoreRepositorio<publisher,pubsContext>
    {
        public EfCorePublisherRepositorio(pubsContext contexto): 
            base(contexto)
        {

        }
    }
}
