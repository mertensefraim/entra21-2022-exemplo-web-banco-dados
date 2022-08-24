using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios
{
    public class VeterinarioRepositorio : IVeterinarioRepositorio
    {
        private readonly ClinicaVeterinarioContexto _contexto;

        public VeterinarioRepositorio(ClinicaVeterinarioContexto contexto)
        {
            _contexto = contexto;
        }

        public Veterinario Cadastrar(Veterinario veterinario)
        {
            _contexto.Veterinarios.Add(veterinario);
            _contexto.SaveChanges();

            return veterinario;
        }

        public IList<Veterinario> ObterTodos(string pesquisa) =>
             _contexto.Veterinarios
                // Nome com LIKE ou CRMV exatamente
                .Where(x => x.Nome.Contains(pesquisa) || x.Crmv == pesquisa)
                .ToList();
        
    }
}
