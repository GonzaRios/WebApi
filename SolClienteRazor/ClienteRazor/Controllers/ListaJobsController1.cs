using ClienteRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;


namespace ClienteRazor.Controllers
{
    public class ListaJobsController1 : Controller
    {
        //url endpoint del servicio
        string strUrl = "https://localhost:7287/api/Jobs";

        // cliente http
        HttpClient cliente = new HttpClient();

        public async Task<IActionResult> Index()
        {
            //invocammos al servicio de Web Api
            var listaJobs = JsonConvert.DeserializeObject<List<VmJobs>>(
                await cliente.GetStringAsync(strUrl)).ToList();
            
            return View(listaJobs);
        }
    }
}
