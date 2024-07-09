using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefasDomain.Interfaces.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;

        public TarefaBusinessValidator Validations { get; }
        public TarefaService(ITarefaRepository tarefaRepository, IProjetoRepository projetoRepository)
        {
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
        }

        public Task<ValidationResult> AddComentario(int idTarefa, Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> EditarTarefa(Tarefa tarefa)
        {            
            var resultBusinessValidator = await Validations.ValidateAsync(tarefa);
            if (!resultBusinessValidator.IsValid)
                return resultBusinessValidator;
            _tarefaRepository.EditarTarefa(tarefa);
            return resultBusinessValidator;
        }

        public Task<ValidationResult> ExcluirTarefa(object idProjeto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetListaTarefaIdProjeto(int IdProjeto)
        {
            throw new NotImplementedException();
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
    }
}
