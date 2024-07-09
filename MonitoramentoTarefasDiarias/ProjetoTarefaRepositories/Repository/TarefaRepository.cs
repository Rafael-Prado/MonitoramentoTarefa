using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTarefaRepositories.Infra;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefaRepositories.Repository
{
    public class TarefaRepository(IServiceProvider serviceProvider) : ITarefaRepository
    {
        private readonly DataContext _context = serviceProvider.GetService<DataContext>();

        public async void EditarTarefa(Tarefa tarefa)
        {
            var tarefaResult = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == tarefa.Id);
            if (tarefaResult == null)
            {
                tarefaResult = tarefa;
                _context.Tarefas.Update(tarefaResult);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasPorIdProjeto(int projetoId)
        {
            return  _context.Tarefas.AsNoTracking().Where(t => t.ProjetoId == projetoId).ToList();
        }

        public void SalvarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }
    }
}
