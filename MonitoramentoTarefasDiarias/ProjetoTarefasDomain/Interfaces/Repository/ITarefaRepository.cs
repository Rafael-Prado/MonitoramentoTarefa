

using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        void EditarTarefa(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> GetTarefasPorIdProjeto(int projetoId);
        void SalvarTarefa(Tarefa tarefa);
    }
}
