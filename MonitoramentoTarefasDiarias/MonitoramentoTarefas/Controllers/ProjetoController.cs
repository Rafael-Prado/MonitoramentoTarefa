
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonitoramentoTarefas.Model;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;

namespace MonitoramentoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {

        private readonly ILogger<ProjetoController> _logger;
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;
        public ProjetoValidator Validations { get; }

        public ProjetoController(ILogger<ProjetoController> logger, IProjetoService projetoService, IMapper mapper)
        {
            _logger = logger;
            _projetoService = projetoService;
            _mapper = mapper;
            Validations = new ProjetoValidator();
        }

        [HttpGet(Name = "GetProjetos")]
        public IEnumerable<Projeto> GetProjeto(int idUsuario)
        {
            return _projetoService.GetListaProjeto(idUsuario);
        }
        [HttpPost(Name = "Projeto")]
        public async Task<IActionResult> SalvarProjeto([FromBody] ProjetoModelView projeto)
        {
            var projetoMap = _mapper.Map<Projeto>(projeto);
            var validationResult = await Validations.ValidateAsync(projetoMap);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(a => a.ErrorMessage).ToList());
            }
            var result = await _projetoService.SalvarProjeto(projetoMap);
           
            return Ok(projeto);
            
        }

        [HttpDelete("{idProjeto}")]
        public async Task<ActionResult> ExcluirProjeto(int idProjeto)
        {
            var result=  await _projetoService.ExcluirProjeto(idProjeto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(a => a.ErrorMessage).ToList());
            }
            return Ok("Excluido com sucesso.");
        }
    }
}
