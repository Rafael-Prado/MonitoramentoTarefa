using ProjetoTarefasDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoTest.EntityFact
{
    public  class ProjetoFact
    {
        public Projeto Build()
        {
            return new Projeto(
                 1,
                 "Teste Projeto",
                "Projeto muito bacana de TI quero participar",
                 ProjetoTarefasDomain.Enuns.TipoProjeto.Tecnologia,
                 1
                );
        }
    }
}
