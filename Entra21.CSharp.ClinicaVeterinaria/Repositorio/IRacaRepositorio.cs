using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinario.Repositorio
{
    public interface IRacaRepositorio
    {
        void Cadastrar(Raca raca);
        List<Raca> ObterTodos();
        void Atualizar(Raca racaParaAlterar);
        void Apagar(int id);
        Raca ObterPorId(int id);
    }
}