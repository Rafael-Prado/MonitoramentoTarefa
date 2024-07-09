using FluentValidation;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Validator
{
    public  class TarefaBusinessValidator : AbstractValidator<Tarefa>
    {
        public TarefaBusinessValidator()
        {
            RuleFor(p => p.Prioridade).NotEmpty().WithMessage(TarefaMessages.PrioridadeVazia);
            RuleFor(tarefa => tarefa).Custom((obj,context) => {
                if (obj.TotalTarefasProjeto >= 20 )
                    context.AddFailure(TarefaMessages.TarefaAcimaLimite);

            });
        }
    }
}
