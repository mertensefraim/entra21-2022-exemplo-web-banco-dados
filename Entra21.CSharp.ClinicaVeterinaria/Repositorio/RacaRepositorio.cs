using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinario.Repositorio
{
    public class RacaRepositorio : IRacaRepositorio
    {
        private readonly ClinicaVeterinarioContexto _contexto;

        public RacaRepositorio(ClinicaVeterinarioContexto contexto)
        {
            _contexto = contexto;
        }

        public void Cadastrar(Raca raca)
        {
            // INSERT INTO na tabela de raças
            _contexto.Racas.Add(raca);
            _contexto.SaveChanges();
        }
    }
}
