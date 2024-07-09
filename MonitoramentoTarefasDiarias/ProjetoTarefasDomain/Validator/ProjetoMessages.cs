
namespace ProjetoTarefasDomain.Validator
{
    public static class ProjetoMessages
    {
        public static string DescricaoNaoVazio = "O campo descricao nao pode ser vazio";
        public static string DescricaoExcedeuTamanhoMinimo = "O campo descricao nao pode ultrapassar{0} caracteres";
        public static string ExisteTarefaPendente = "Projeto nao pode ser excluido existe tarefa pendente.";
    }
}
