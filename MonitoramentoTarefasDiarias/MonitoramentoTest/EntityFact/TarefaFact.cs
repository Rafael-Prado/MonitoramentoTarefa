﻿using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Enuns;

namespace MonitoramentoTest.EntityFact
{
    public class TarefaFact
    {
        public Tarefa Build()
        {
            return new Tarefa(
                 1,
                 "Teste Tarefa",
                "Tarefa muito bacana de TI quero participar",
                 DateTime.Now,                
                 Prioridade.Media,
                 1,
                 Status.pendente,
                 new List<Comentario>()
                );
        }
    }
}