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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Raca>().ToTable("racas");
        }
    }
}
