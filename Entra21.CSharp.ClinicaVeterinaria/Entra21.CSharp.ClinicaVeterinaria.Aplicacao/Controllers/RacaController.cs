using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;

        public RacaController(ClinicaVeterinarioContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [HttpGet("/raca")]
        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            return View("Index", racas);
        }

        [HttpGet("/raca/cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Especies = ObterEspecies();

            var racaCadastrarViewModel = new RacaCadastrarViewModel();

            return View(racaCadastrarViewModel);
        }

        [HttpPost("/raca/cadastrar")]
        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModel racaCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();
            
                return View(racaCadastrarViewModel);
            }
            _racaServico.Cadastrar(racaCadastrarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("/raca/apagar")]
        // https://localhost:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery] int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            var racaEditarViewModel = new RacaEditarViewModel
            {
                Id = raca.Id,
                Nome = raca.Nome,
                Especie = raca.Especie
            };

            ViewBag.Especies = especies;

            return View(racaEditarViewModel);
        }


        [HttpPost("/raca/editar")]
        public IActionResult Editar(
            [FromForm] RacaEditarViewModel racaEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();

                return View(racaEditarViewModel);
            }
            
            _racaServico.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>().OrderBy(x => x).ToList();
        }
    }
}
