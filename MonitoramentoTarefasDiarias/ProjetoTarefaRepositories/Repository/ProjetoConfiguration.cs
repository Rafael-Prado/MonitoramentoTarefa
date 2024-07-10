using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefaRepositories.Repository
{
    public  class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Tarefas).WithOne(p => p.Projeto).HasForeignKey(p => p.Id);
            builder.HasMany(e => e.Tarefas)
                .WithOne(e => e.Projeto)
                .HasForeignKey(e => e.ProjetoId)
                .HasPrincipalKey(e => e.Id);


        }
    }
}
