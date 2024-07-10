using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoTarefasDomain.Interfaces.Services.Interfaces;

namespace MonitoramentoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioTarefaController : ControllerBase
    {
        private readonly ITarefaService _service;

        public RelatorioTarefaController(ITarefaService service)
        {
            _service = service; 
        }
        [HttpGet(Name = "Relatorio Media tarefa")]
        public double GetMediaTarefa(int idUsuario, DateTime dtInicio, DateTime dtFim) => _service.GetMediaTarefa(idUsuario, dtInicio, dtFim);
        
    }
}
