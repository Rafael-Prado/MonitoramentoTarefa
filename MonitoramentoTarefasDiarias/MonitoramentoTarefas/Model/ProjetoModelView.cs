
using ProjetoTarefasDomain.Enuns;
using System.Text.Json.Serialization;

namespace MonitoramentoTarefas.Model
{
    public class ProjetoModelView
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoProjeto TipoProjeto { get; set; }
        public int UsuarioId { get; set; }
    }
}
