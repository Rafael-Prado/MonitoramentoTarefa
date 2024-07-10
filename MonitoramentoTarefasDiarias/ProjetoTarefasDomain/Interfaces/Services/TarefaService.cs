using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;

namespace ProjetoTarefasDomain.Interfaces.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaBusinessValidator Validations { get; } = new TarefaBusinessValidator();
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<ValidationResult> AddComentario(int idTarefa, Comentario comentario)
        {
            _tarefaRepository.AddComentario(comentario);
            return new ValidationResult();
        }

        public async Task<ValidationResult> EditarTarefa(Tarefa tarefa)
        {            
            var resultBusinessValidator = await Validations.ValidateAsync(tarefa);
            if (!resultBusinessValidator.IsValid)
                return resultBusinessValidator;
            _tarefaRepository.EditarTarefa(tarefa);
            return resultBusinessValidator;
        }

        public async Task<ValidationResult> ExcluirTarefa(int idTarefa)
        {
            _tarefaRepository.ExcluirTarefa(idTarefa);
            return new ValidationResult();
        }

        public Task<IEnumerable<Tarefa>> GetListaTarefaIdProjeto(int IdProjeto)
        {
            return _tarefaRepository.GetTarefasPorIdProjeto(IdProjeto);
        }

        public async Task<ValidationResult> SalvarTarefa(Tarefa tarefa)
        {
            var tarefas =  await _tarefaRepository.GetTarefasPorIdProjeto(tarefa.ProjetoId);
            tarefa.TotalTarefasProjeto = tarefas.Count();
            var resultBusinessValidator = await Validations.ValidateAsync(tarefa);
            if (!resultBusinessValidator.IsValid)
                return resultBusinessValidator;
            _tarefaRepository.SalvarTarefa(tarefa);
            return resultBusinessValidator;

        }

        public double GetMediaTarefa(int idUsuario, DateTime dtInicio, DateTime dtFim)
        {
            var tarefas = _tarefaRepository.GetMediaTarefa(idUsuario);
            var tarefaNoPeriodo = tarefas
            .Where(c => c.DataVencimento >= dtInicio && c.DataVencimento <= dtFim)
            .ToList();
            int diasNoPeriodo = (dtFim - dtInicio).Days + 1;
            return (double)tarefaNoPeriodo.Count / diasNoPeriodo;

        }
    }
}
