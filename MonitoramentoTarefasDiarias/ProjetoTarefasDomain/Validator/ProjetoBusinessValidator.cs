using FluentValidation;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Validator
{
    public class ProjetoBusinessValidator : AbstractValidator<Projeto>
    {
        public ProjetoBusinessValidator()
        {
            RuleFor(projeto => projeto).Custom((obj, context) =>
            {
                if (obj.Tarefas.Any(x => x.Status == Enuns.Status.pendente))
                    context.AddFailure(ProjetoMessages.ExisteTarefaPendente);

            });
        }
    }
}
