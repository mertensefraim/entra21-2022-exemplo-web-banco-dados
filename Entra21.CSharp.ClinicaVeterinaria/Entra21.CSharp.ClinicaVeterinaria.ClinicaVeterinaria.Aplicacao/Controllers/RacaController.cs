using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {
        [Route("/raca")]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return View();
        }
    }
}
