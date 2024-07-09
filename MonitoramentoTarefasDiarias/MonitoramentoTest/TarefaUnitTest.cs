using FluentValidation;
using MonitoramentoTest.EntityFact;
using ProjetoTarefasDomain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoTest
{
    public class TarefaUnitTest
    {
        public TarefaUnitTest()
        {

        }

        [Fact]
        public void TarefaDeveserValida()
        {
            var tarefa = new TarefaFact().Build();

            var result = new TarefaValidator()
                        .Validate(tarefa);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void LimiteTarefaDeveSer20()
        {
            var tarefa = new TarefaFact().Build();
            tarefa.TotalTarefasProjeto = 21;

            var result = new TarefaBusinessValidator()
                        .Validate(tarefa);
            Assert.False(result.IsValid);
            var erros = result.Errors.Select(x => x.ErrorMessage).ToList();
            Assert.True(erros.Contains(TarefaMessages.TarefaAcimaLimite) == true);
        }
    }
}
