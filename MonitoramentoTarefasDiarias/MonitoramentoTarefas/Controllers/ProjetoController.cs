
using Microsoft.AspNetCore.Mvc;
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
        public ProjetoValidator Validations { get; }

        public ProjetoController(ILogger<ProjetoController> logger, IProjetoService projetoService)
        {
            _logger = logger;
            _projetoService = projetoService;
        }

        [HttpGet(Name = "GetProjetos")]
        public IEnumerable<Projeto> GetProjeto(int idUsuario)
        {
            return _projetoService.GetListaProjeto(idUsuario);
        }
        [HttpPost(Name = "Projeto")]
        public async Task<IActionResult> SalvarProjeto([FromBody]  Projeto projeto)
        {
            var validationResult = await Validations.ValidateAsync(projeto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(a => a.ErrorMessage).ToList());
            }
            var result = await _projetoService.SalvarProjeto(projeto);
           
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
