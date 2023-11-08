using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWebApi.Models;
using ServicioWebApi.Repositorios;
using ServicioWebApi.Data;

namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : BaseController<Articulo, RepoArticuloEF>
    {
        public ArticulosController(RepoArticuloEF repo) : base(repo)
        {

        }
    }
}
