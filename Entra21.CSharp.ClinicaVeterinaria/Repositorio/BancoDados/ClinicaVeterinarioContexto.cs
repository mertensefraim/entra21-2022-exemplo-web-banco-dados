using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;
using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinario.Repositorio.BancoDados
{
    public class ClinicaVeterinarioContexto : DbContext
    {
        public DbSet<Raca> Racas { get; set; }

        public ClinicaVeterinarioContexto(DbContextOptions<ClinicaVeterinarioContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Documentação: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
            * Necessário instalar a ferramenta do dotnet ef core
            *          dotnet tool install --global dotnet-ef

            * 1ª etapa- Criar a entidade
            * 2ª etapa - Criar o mapeamento da entidade para tabela
            * 3ª etapa - Registrar o mapeamento
            * 4ª etapa - Gerar a migration
            *          dotnet ef migrations add NomeMigration --project Repositorio --startup-project Entra21.CSharp.ClinicaVeterinaria.Aplicacao
            * 5ª etapa - A migration poderá ser aplicada de duas formas:
            *    - executar comando para aplicar a migration sem a
            *          necessidade de executar a aplicação
            *          dotnet ef database update --project .\Repositorio --startup-project .\Entra21.CSharp.ClinicaVeterinaria.Aplicacao
            *     - executar a aplicação irá aplicar a migration */

            modelBuilder.ApplyConfiguration(new RacaMapeamento());

        }
    }
}
