
namespace ProjetoTarefasDomain.Entity
{
    public  class Comentario
    {
        public int IdTarefa { get; set; }
        public required string Descricao { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
