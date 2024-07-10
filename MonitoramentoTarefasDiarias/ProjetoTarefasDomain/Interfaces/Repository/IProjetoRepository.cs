using ProjetoTarefasDomain.Entity;

namespace ProjetoTarefasDomain.Interfaces.Repository
{
    public  interface IProjetoRepository
    {
        IEnumerable<Projeto> GetListaProjeto(int IdUsuario);
        void SalvarProjeto(Projeto projeto);
        void ExcluirProjeto(int idProjeto);
        Projeto GetProjetoPorId(int idProjeto);
    }
}
