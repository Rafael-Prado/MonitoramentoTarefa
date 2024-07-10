using ProjetoTarefasDomain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTarefasDomain.Entity
{
    public  class Projeto
    {
        public Projeto(int id, string nome, string descricao, TipoProjeto tipoProjeto, int usuarioId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TipoProjeto = tipoProjeto;
            UsuarioId = usuarioId;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoProjeto TipoProjeto { get; set; }
        public int UsuarioId { get; set; } 
        public virtual IEnumerable<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

    }
}
