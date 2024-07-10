using AutoMapper;
using MonitoramentoTarefas.Model;
using ProjetoTarefasDomain.Entity;


namespace MonitoramentoTarefas.AutoMapper
{
    public class ConfigurationMapping: Profile
    {
        public ConfigurationMapping()
        {
            CreateMap < ProjetoModelView, Projeto> ();
            CreateMap<Projeto, ProjetoModelView>();
            CreateMap<TarefaViewModel, Tarefa>();
            CreateMap<Tarefa, TarefaViewModel>();
        }
    }
}
