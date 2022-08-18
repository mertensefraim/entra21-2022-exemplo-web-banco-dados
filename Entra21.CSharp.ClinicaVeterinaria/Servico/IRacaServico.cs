using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    public interface IRacaServico
    {
        void Cadastrar(RacaCadastrarViewModel raca);
        List<Raca> ObterTodos();
        void Editar(RacaEditarViewModel racaEditarViewModel);
        void Apagar(int id);
        Raca ObterPorId(int id);
    }
}
