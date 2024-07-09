using FluentValidation;
using ProjetoTarefasDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefasDomain.Validator
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator() {
            RuleFor(p => p.Descricao).NotEmpty().WithMessage(ProjetoMessages.DescricaoNaoVazio).
                MaximumLength(250).WithMessage(ProjetoMessages.DescricaoExcedeuTamanhoMinimo);            
        }
    }
}
