using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MonitoramentoTarefas.Model;
using ProjetoTarefasDomain.Entity;
using ProjetoTarefasDomain.Interfaces.Services;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;
using ProjetoTarefasDomain.Validator;

namespace MonitoramentoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {

        private readonly ILogger<ProjetoController> _logger;
        private readonly ITarefaService _service;
        private readonly IMapper _mapper;
        public TarefaValidator Validations { get; } = new TarefaValidator();
        public TarefaController(ILogger<ProjetoController> logger, ITarefaService service,IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTarefas")]
        public async Task<IEnumerable<Tarefa>>GetTarefasPorProjeto(int idProjeto)
        {
            return await _service.GetListaTarefaIdProjeto(idProjeto);
        }

        [HttpPost(Name = "Tarefa")]
        public async Task<IActionResult> SalvarProjeto([FromBody] TarefaViewModel tarefa)
        {

            var validationResult = await Validations.ValidateAsync(_mapper.Map<Tarefa>(tarefa));
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(a => a.ErrorMessage).ToList());
            }
            var result = await _service.SalvarTarefa(_mapper.Map<Tarefa>(tarefa));

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(a => a.ErrorMessage).ToList());

            return Ok(tarefa);

        }


        [HttpPut("Editar")]
        public async Task<ActionResult> EditarTarefa([FromBody] TarefaViewModel tarefa)
        {
            var result = await _service.EditarTarefa(_mapper.Map<Tarefa>(tarefa));
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(a => a.ErrorMessage).ToList());
            }
            return Ok("Excluido com sucesso.");
        }

        [HttpPatch("AddComentario")]
        public async Task<ActionResult> AddComentario(int idTarefa , [FromBody] Comentario comentario)
        {
            var result = await _service.AddComentario(idTarefa, comentario);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(a => a.ErrorMessage).ToList());
            }
            return Ok("Comentario Adicionado com sucesso.");
        }

        [HttpDelete("{idTarefa}")]
        public async Task<ActionResult> ExcluirTarefa(int idTarefa)
        {
            var result = await _service.ExcluirTarefa(idTarefa);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(a => a.ErrorMessage).ToList());
            }
            return Ok("Excluido com sucesso.");
        }


    }
}
