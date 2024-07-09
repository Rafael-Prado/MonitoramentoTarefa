using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefaRepositories.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        public void ExcluirProjeto(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projeto> GetListaProjeto(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Projeto GetProjetoPorId(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTarefaPendetePorIdProjeto(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public Projeto SalvarProjeto(Projeto projeto)
        {
            throw new NotImplementedException();
        }
    }
}
