using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinario.Repositorio
{
    public class RacaRepositorio : IRacaRepositorio
    {
        private readonly ClinicaVeterinarioContexto _contexto;

        public RacaRepositorio(ClinicaVeterinarioContexto contexto)
        {
            // dsadsadasdasdadsasd
            _contexto = contexto;
        }

        public void Cadastrar(Raca raca)
        {
            // INSERT INTO na tabela de raças
            _contexto.Racas.Add(raca);
            _contexto.SaveChanges();
        }

        public List<Raca> ObterTodos()
        {
            // Buscar todos os registros de raças
            // SELECT * FROM racas
            var racas = _contexto.Racas.ToList();

            return racas;
        }

        public void Atualizar(Raca racaParaAlterar)
        {
            var raca = _contexto.Racas.Where(x => x.Id == racaParaAlterar.Id).FirstOrDefault();
            //var raca = _contexto.Racas.FirstOrDefault(x => x.Id == racaParaAlterar.Id);

            raca.Nome = racaParaAlterar.Nome;
            raca.Especie = racaParaAlterar.Especie;

            _contexto.Update(raca);
            _contexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var raca = _contexto.Racas.Where(x => x.Id == id).FirstOrDefault();

            _contexto.Racas.Remove(raca);
            _contexto.SaveChanges();
        }

        public Raca ObterPorId(int id)
        {
            var raca = _contexto.Racas.Where(x => x.Id == id).FirstOrDefault();

            return raca;
        }
    }
}
