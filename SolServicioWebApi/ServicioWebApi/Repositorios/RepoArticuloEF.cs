using ServicioWebApi.Data;
using ServicioWebApi.Models;

namespace ServicioWebApi.Repositorios
{
    public class RepoArticuloEF : EfCoreRepositorio<Articulo, pubsContext>
    {
        public RepoArticuloEF(pubsContext contexto): base(contexto)
        {

        }
    }
}
