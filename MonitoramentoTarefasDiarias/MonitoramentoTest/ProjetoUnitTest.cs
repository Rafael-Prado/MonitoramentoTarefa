using MonitoramentoTest.EntityFact;
using ProjetoTarefasDomain.Validator;

namespace MonitoramentoTest
{
    public class ProjetoUnitTest
    {
        public ProjetoUnitTest()
        {
            
        }
        [Fact]
        public void ProjetoDeveserValido()
        {
            var projeto = new ProjetoFact().Build();

            var result = new ProjetoValidator()
                        .Validate(projeto); 
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ProjetoDeveserInValido()
        {
            var projeto = new ProjetoFact().Build();
            projeto.Descricao =string.Empty;

            var result = new ProjetoValidator()
                        .Validate(projeto);
            Assert.False(result.IsValid);
            var erros = result.Errors.Select(x => x.ErrorMessage).ToList();
            Assert.True(erros.Contains(ProjetoMessages.DescricaoNaoVazio) == true);
        }
    }
}