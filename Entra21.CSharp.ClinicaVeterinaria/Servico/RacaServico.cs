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
        private readonly RacaRepositorio _racaRepositorio;

        // Construtor: construir o objeto de RacaServico cim o mínimo para a correta execução
        public RacaServico(ClinicaVeterinarioContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }

        // A classe RacaServico irá implementar a interface IRacaService,
        // ou seja, deverá honrar as clausulas definidos na interface(contrato)
        public void Cadastrar(string nome, string especie)
        {
            var raca = new Raca();
            raca.Nome = nome;
            raca.Especie = especie;

            _racaRepositorio.Cadastrar(raca);
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }

        public void Editar(int id, string nome, string especie)
        {
            var raca = new Raca();

            raca.Id = id;
            raca.Nome = nome;
            raca.Especie = especie;
            
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
