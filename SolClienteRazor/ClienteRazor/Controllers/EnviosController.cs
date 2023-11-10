using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClienteRazor.Models;

namespace ClienteRazor.Controllers
{
    public class EnviosController : Controller
    {
        //endpoint
        string strURL = "https://localhost:7193/api/publishers";
        // una instancia de la clase HttpClient
        HttpClient cliente = new HttpClient();

        public async Task<IActionResult> Index()
        {
            var listaPublishers = JsonConvert.DeserializeObject<List<publisher>>
                (await cliente.GetStringAsync(strURL)).ToList();

            return View(listaPublishers);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(publisher publisher)
        {
            // llamo al servicio de la api REST

            await cliente.PostAsJsonAsync(strURL, publisher);
            return RedirectToAction("Index");
        }
    }
}
