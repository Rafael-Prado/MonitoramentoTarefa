using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefaRepositories.Repository
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(p => p.Id);
            builder.HasMany(e => e.Comentarios)
                .WithOne(e => e.Tarefa)
                .HasForeignKey(e => e.IdTarefa)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
