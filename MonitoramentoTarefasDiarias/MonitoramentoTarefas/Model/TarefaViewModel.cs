using ProjetoTarefasDomain.Enuns;

namespace MonitoramentoTarefas.Model
{
    public class TarefaViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Prioridade Prioridade { get; set; }
        public int ProjetoId { get; set; }
        public Status Status { get; set; }
    }
}
