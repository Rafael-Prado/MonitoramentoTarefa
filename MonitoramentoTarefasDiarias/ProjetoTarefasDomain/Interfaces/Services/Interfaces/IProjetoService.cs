using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;
namespace ProjetoTarefasDomain.Interfaces.Services.Interfaces
{
    public  interface IProjetoService
    {
        IEnumerable<Projeto> GetListaProjeto(int IdUsuario);
        Task<Projeto> SalvarProjeto(Projeto projeto);
        Task<ValidationResult> ExcluirProjeto(int idProjeto);
    }
}
