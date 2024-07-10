using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTarefaRepositories.Infra;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Enuns;
using ProjetoTarefasDomain.Interfaces.Repository;

namespace ProjetoTarefaRepositories.Repository
{
    public class TarefaRepository(IServiceProvider serviceProvider, IConfiguration configuration) : ITarefaRepository
    {
        private readonly DataContext _context = serviceProvider.GetService<DataContext>();
        private readonly IConfiguration _configuration = configuration;
        public void AddComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public string GetConnection() => _configuration.GetSection("ConnectionStrings").Value;

        public async void EditarTarefa(Tarefa tarefa)
        {
            var tarefaResult = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == tarefa.Id);
            if (tarefaResult == null)
            {               
                tarefaResult.Titulo = tarefa.Titulo;
                tarefaResult.Status = tarefa.Status;
                tarefaResult.Descricao = tarefa.Descricao;
                _context.Tarefas.Update(tarefaResult);
                await _context.SaveChangesAsync();
            }
        }

        public void ExcluirTarefa(int idTarefa)
        {
            var tarefa = _context.Tarefas.AsNoTracking().Where(t => t.Id == idTarefa).FirstOrDefault();
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }       

        public async Task<IEnumerable<Tarefa>> GetTarefasPorIdProjeto(int projetoId)
        {
            return  _context.Tarefas.AsNoTracking().Where(t => t.ProjetoId == projetoId).ToList();
        }

        public void SalvarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }


        public IEnumerable<Tarefa> GetMediaTarefa(int idUsuario)
        {
            var connectionString = this.GetConnection();
            var tarefa = new List<Tarefa>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"Select t.* from Projeto p 
                          join Tarefa t on p.Id = t.ProjetoId
                          where t.Status = 3 and p.UsuarioId=" + idUsuario; ;
                    tarefa = con.Query<Tarefa>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return tarefa;
            }
        }
    }
}
