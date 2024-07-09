using ProjetoTarefasDomain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefasDomain.Entity
{
    public  class Projeto
    {
        public Projeto(int id, string nome, string descricao, TipoProjeto tipoProjeto, int usuarioId, IEnumerable<Tarefa> tarefas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TipoProjeto = tipoProjeto;
            UsuarioId = usuarioId;
            Tarefas = tarefas;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoProjeto TipoProjeto { get; set; }
        public int UsuarioId { get; set; } 
        public virtual IEnumerable<Tarefa> Tarefas { get; set; }

    }
}
