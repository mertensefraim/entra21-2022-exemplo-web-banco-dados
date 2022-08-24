using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas;
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
