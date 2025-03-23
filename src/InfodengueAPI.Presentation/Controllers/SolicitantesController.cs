using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfodengueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitantesController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;
        private readonly ILogger<SolicitantesController> _logger;

        public SolicitantesController(ISolicitanteService solicitanteService, ILogger<SolicitantesController> logger)
        {
            _solicitanteService = solicitanteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitante>>> GetSolicitantes()
        {
            try
            {
                var solicitantes = await _solicitanteService.ObterTodosAsync();
                return Ok(solicitantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar solicitantes");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
