using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {
        private readonly RacaServico _racaServico;

        public RacaController(ClinicaVeterinarioContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [Route("/raca")]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("/raca/registrar")]
        [HttpGet]
        public IActionResult Registrar(
            [FromQuery] string nome,
            [FromQuery] string especie)
        {

            _racaServico.Cadastrar(nome, especie);
            return RedirectToAction("Index");
        }
    }
}
