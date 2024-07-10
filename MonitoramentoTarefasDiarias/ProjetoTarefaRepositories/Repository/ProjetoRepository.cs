using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTarefaRepositories.Infra;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;

namespace ProjetoTarefaRepositories.Repository
{
    public class ProjetoRepository(IServiceProvider serviceProvider) : IProjetoRepository
    {
        private readonly DataContext _context = serviceProvider.GetService<DataContext>();
        public void ExcluirProjeto(int idProjeto)
        { 
            var projeto = GetProjetoPorId(idProjeto);
            _context.Projetos.Remove(projeto);
            _context.SaveChanges();
        }

        public IEnumerable<Projeto> GetListaProjeto(int IdUsuario)
        {
            return _context.Projetos.AsNoTracking().Where(t => t.UsuarioId == IdUsuario).ToList();
        }

        public Projeto GetProjetoPorId(int idProjeto)
        {
            return _context.Projetos.AsNoTracking().Where(t => t.Id == idProjeto).FirstOrDefault();
        }

        public void SalvarProjeto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }
    }
}
