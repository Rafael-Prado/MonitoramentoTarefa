using FluentValidation;
using ProjetoTarefasDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefasDomain.Validator
{
    public  class ProjetoBusinessValidator : AbstractValidator<Projeto>
    {
        public ProjetoBusinessValidator() {
            RuleFor(p => p.Tarefas.Count()).NotEqual(0).WithMessage(ProjetoMessages.ExisteTarefaPendente);
        }
    }
}
