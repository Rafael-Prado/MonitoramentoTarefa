
using System.ComponentModel.DataAnnotations;

namespace ProjetoTarefasDomain.Entity
{
    public  class Comentario
    {
        [Key]
        public int Id { get; set; }
        public int IdTarefa { get; set; }
        public string Descricao { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
