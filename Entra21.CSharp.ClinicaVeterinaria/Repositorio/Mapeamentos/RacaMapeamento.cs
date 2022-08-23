using Entra21.CSharp.ClinicaVeterinario.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    // DB First: criar uma aplicação onde o banco de dados já existe
    // Code Fist: criar um banco de dados a partir de uma aplicação existente
    // Seed: alimentar o banco de dados com registros
    // Migration: representação do mapeamento que será aplicado no BD 
    // Mapeamento: representação da entidade em tabelas, clounas, indices....
    internal class RacaMapeamento : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("racas");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Especie)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("especie"); // Not null

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("nome"); // Not null

            builder.HasData(
                new Raca
                {
                    Id = 1,
                    Nome = "Frajola",
                    Especie = "Gato"
                },
                new Raca
                {
                    Id = 2,
                    Nome = "Piupiu",
                    Especie = "Capivara"
                });
        }
    }
}
