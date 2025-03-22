using InfodengueAPI.Models;
using InfodengueAPI.Models.Dtos;
using InfodengueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfodengueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;
        private readonly ILogger<RelatoriosController> _logger;

        public RelatoriosController(IRelatorioService relatorioService, ILogger<RelatoriosController> logger)
        {
            _relatorioService = relatorioService;
            _logger = logger;
        }

        // POST: api/relatorios
        [HttpPost]
        public async Task<ActionResult<Relatorio>> CreateRelatorio([FromBody] NovoRelatorioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var relatorio = await _relatorioService.CreateAsync(
                    request.Nome,
                    request.CPF,
                    request.Arbovirose,
                    request.SemanaInicio,
                    request.SemanaFim,
                    request.CodigoIBGE);

                return CreatedAtAction(nameof(GetRelatorio), new { id = relatorio.Id }, relatorio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar relatório para {Nome}, CPF: {CPF}", request.Nome, request.CPF);
                return StatusCode(500, "Erro interno ao processar solicitação");
            }
        }

        // GET: api/relatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relatorio>>> GetRelatorios()
        {
            try
            {
                var relatorios = await _relatorioService.GetAllAsync();
                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar relatórios");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relatorio>> GetRelatorio(int id)
        {
            try
            {
                var relatorio = await _relatorioService.GetByIdAsync(id);
                if (relatorio == null)
                {
                    return NotFound();
                }
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar relatório com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/municipio/3304557
        [HttpGet("municipio/{codigoIBGE}")]
        public async Task<ActionResult<IEnumerable<Relatorio>>> GetRelatoriosPorMunicipio(string codigoIBGE)
        {
            try
            {
                var relatorios = await _relatorioService.GetByMunicipioCodigoIBGEAsync(codigoIBGE);
                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar relatórios para o município {CodigoIBGE}", codigoIBGE);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/dados-rj-sp
        [HttpGet("dados-rj-sp")]
        public async Task<ActionResult<IEnumerable<Relatorio>>> GetDadosRioSaoPaulo()
        {
            try
            {
                var relatorios = await _relatorioService.GetDadosRioSaoPauloAsync();
                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar dados epidemiológicos do Rio de Janeiro e São Paulo");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/total-casos-rj-sp
        [HttpGet("total-casos-rj-sp")]
        public async Task<ActionResult<IEnumerable<object>>> GetTotalCasosRioSaoPaulo()
        {
            try
            {
                var resultado = await _relatorioService.GetTotalCasosRioSaoPauloAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar total de casos do Rio de Janeiro e São Paulo");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/total-por-arbovirose
        [HttpGet("total-por-arbovirose")]
        public async Task<ActionResult<IEnumerable<object>>> GetTotalCasosPorArbovirose()
        {
            try
            {
                var resultado = await _relatorioService.GetTotalCasosPorArboviroseAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar total de casos por arbovirose");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // GET: api/relatorios/filtro?codigoIBGE=3304557&semanaInicio=1&semanaFim=52&arbovirose=dengue
        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<Relatorio>>> GetRelatoriosFiltrados(
            [FromQuery] string codigoIBGE,
            [FromQuery] int semanaInicio,
            [FromQuery] int semanaFim,
            [FromQuery] string arbovirose)
        {
            try
            {
                var relatorios = await _relatorioService.GetFiltradoAsync(
                    codigoIBGE, semanaInicio, semanaFim, arbovirose);
                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar relatórios filtrados");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
