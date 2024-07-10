using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Interfaces.Services.Interfaces
{
    public  interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetListaTarefaIdProjeto(int IdProjeto);
        Task<ValidationResult> SalvarTarefa(Tarefa tarefa);
        Task<ValidationResult> EditarTarefa(Tarefa tarefa);
        Task<ValidationResult> ExcluirTarefa(int idTarefa);
        Task<ValidationResult> AddComentario(int idTarefa, Comentario comentario);
        double GetMediaTarefa(int idUsuario, DateTime dtInicio, DateTime dtFim);
    }
}
