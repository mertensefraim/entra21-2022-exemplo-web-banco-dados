using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Enums;
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
            var racas = _racaServico.ObterTodos();
            
            // Passar informações do C# para o HTML
            ViewBag.Racas = racas;
            
            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();

            ViewBag.Especies = especies;

            return View();
        }

        [Route("/raca/cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] string nome,
            [FromForm] string especie)
        {
            _racaServico.Cadastrar(nome, especie);
            return RedirectToAction("Index");
        }

        [Route("/raca/apagar")]
        [HttpGet]
        // https://localhost:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery] int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [Route("/raca/editar")]
        [HttpGet]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especies = especies;

            return View("Editar");
        }


        [Route("/raca/alterar")]
        [HttpPost]
        public IActionResult Alterar(
            [FromForm] int id,
            [FromForm] string nome, 
            [FromForm] string especie)
        {
            _racaServico.Editar(id, nome, especie);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>().OrderBy(x => x).ToList();
        }
    }
}
