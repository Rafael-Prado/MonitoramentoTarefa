using FluentValidation;
using FluentValidation.Results;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Repository;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;


namespace ProjetoTarefasDomain.Interfaces.Services
{
    public class ProjetoService(IProjetoRepository projetoRepository) : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;
        public ProjetoBusinessValidator ValidationsBusiness { get; } = new ProjetoBusinessValidator();

        public IEnumerable<Projeto> GetListaProjeto(int IdUsuario)
        {
            return _projetoRepository.GetListaProjeto(IdUsuario);
        }

        public async Task<Projeto> SalvarProjeto(Projeto projeto)
        {            
            _projetoRepository.SalvarProjeto(projeto);
            return projeto;
        }

        public async Task<ValidationResult> ExcluirProjeto(int idProjeto)
        {
            var projeto = _projetoRepository.GetProjetoPorId(idProjeto);
            var resultBusinessValidation = await ValidationsBusiness.ValidateAsync(projeto);
            if (!resultBusinessValidation.IsValid)
            {
                return resultBusinessValidation;
            }
            _projetoRepository.ExcluirProjeto(idProjeto);
            return resultBusinessValidation;

        }
    }
}
