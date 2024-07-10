

using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        void AddComentario(Comentario comentario);
        void EditarTarefa(Tarefa tarefa);
        void ExcluirTarefa(int idTarefa);
        IEnumerable<Tarefa> GetMediaTarefa(int idUsuario);
        Task<IEnumerable<Tarefa>> GetTarefasPorIdProjeto(int projetoId);
        void SalvarTarefa(Tarefa tarefa);
    }
}
