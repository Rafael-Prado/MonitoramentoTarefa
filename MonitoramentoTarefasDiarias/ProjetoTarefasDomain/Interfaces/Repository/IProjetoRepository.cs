using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Interfaces.Repository
{
    public  interface IProjetoRepository
    {
        IEnumerable<Projeto> GetListaProjeto(int IdUsuario);
        Projeto SalvarProjeto(Projeto projeto);
        Task<bool> GetTarefaPendetePorIdProjeto(int idProjeto);
        void ExcluirProjeto(int idProjeto);
        Projeto GetProjetoPorId(int idProjeto);
    }
}
