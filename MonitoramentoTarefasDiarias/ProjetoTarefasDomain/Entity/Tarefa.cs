using ProjetoTarefasDomain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTarefasDomain.Entity
{
    public  class Tarefa
    {
        public Tarefa(string titulo, string descricao, DateTime dataVencimento, Prioridade prioridade, int projetoId, Status status)
        {
            Id = 0;
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            ProjetoId = projetoId;
            Status = status;
        }

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Prioridade Prioridade { get; set; }
        public int ProjetoId { get; set; }
        public Status Status { get; set; }
        public virtual int TotalTarefasProjeto { get; set; }

        public virtual IEnumerable<Comentario> Comentarios { get; set; }
        public virtual Projeto Projeto { get; set; }


    }
}
