using InfodengueAPI.Models;
using InfodengueAPI.Services;
using Microsoft.AspNetCore.Http;
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
                var solicitantes = await _solicitanteService.GetAllAsync();
                return Ok(solicitantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar solicitantes");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/solicitantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitante>> GetSolicitante(int id)
        {
            try
            {
                var solicitante = await _solicitanteService.GetByIdAsync(id);
                if (solicitante == null)
                {
                    return NotFound();
                }
                return Ok(solicitante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar solicitante com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/solicitantes/cpf/12345678900
        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<Solicitante>> GetSolicitanteByCPF(string cpf)
        {
            try
            {
                var solicitante = await _solicitanteService.GetByCPFAsync(cpf);
                if (solicitante == null)
                {
                    return NotFound();
                }
                return Ok(solicitante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar solicitante com CPF {CPF}", cpf);
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
