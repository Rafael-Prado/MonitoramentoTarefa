using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoTarefaRepositories.Repository;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefaRepositories.Infra
{
    public class DataContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost;Database=Monitoramento;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
        }
    }
}
