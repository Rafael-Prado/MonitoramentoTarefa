using FluentValidation;
using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Validator
{
    public  class ProjetoValidator: AbstractValidator<Projeto>
    {
        public ProjetoValidator()
        {
            RuleFor(p => p.Descricao).NotEmpty().WithMessage(ProjetoMessages.DescricaoNaoVazio).
                MaximumLength(250).WithMessage(ProjetoMessages.DescricaoExcedeuTamanhoMinimo);

        }
    }
}
