using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinario.Repositorio;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    public class RacaServico : IRacaServico
    {
        private readonly IRacaRepositorio _racaRepositorio;

        // Construtor: construir o objeto de RacaServico cim o mínimo para a correta execução
        public RacaServico(ClinicaVeterinarioContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }

        // A classe RacaServico irá implementar a interface IRacaService,
        // ou seja, deverá honrar as clausulas definidos na interface(contrato)
        public void Cadastrar(RacaCadastrarViewModel racaCadastrarViewModel)
        {
            var raca = new Raca();
            raca.Nome = racaCadastrarViewModel.Nome;
            raca.Especie = racaCadastrarViewModel.Especie;

            _racaRepositorio.Cadastrar(raca);
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }

        public void Editar(RacaEditarViewModel racaEditarViewModel)
        {
            var raca = new Raca();

            raca.Id = racaEditarViewModel.Id;
            raca.Nome = racaEditarViewModel.Nome;
            raca.Especie = racaEditarViewModel.Especie;
            
            _racaRepositorio.Atualizar(raca);
        }

        public void Apagar(int id)
        {
            _racaRepositorio.Apagar(id);
        }

        public Raca ObterPorId(int id)
        {
            var raca = _racaRepositorio.ObterPorId(id);

            return raca;
        }
    }
}
