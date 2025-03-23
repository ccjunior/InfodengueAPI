using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Domain.Dtos;
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

        [HttpPost]
        public async Task<IActionResult> CreateRelatorio([FromBody] RelatorioRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var relatorio = await _relatorioService.AdcionarAsync(request);

                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar relatório para {Nome}, CPF: {CPF}", request.Nome, request.CPF);
                return StatusCode(500, "Erro interno ao processar solicitação");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtertTodos()
        {
            try
            {
                var relatorios = await _relatorioService.ObterTodos();

                if (relatorios == null)
                    return NotFound();

                return Ok(relatorios);
            }
            catch (Exception ex)
            {
               return StatusCode(500, "Erro interno ao processar solicitação");
            }
        }

        [HttpGet("dados-rj-sp")]
        public async Task<IActionResult> GetDadosRioSaoPaulo()
        {
            try
            {
                var relatorios = await _relatorioService.ObterDadosRioSaoPauloAsync();

                if (relatorios == null)
                    return NotFound();

                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar dados epidemiológicos do Rio de Janeiro e São Paulo");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet("municipio/{codigoIBGE}")]
        public async Task<IActionResult> GetRelatoriosPorMunicipio(string codigoIBGE)
        {
            try
            {
                var relatorios = await _relatorioService.ObterMunicipioCodigoIBGEAsync(codigoIBGE);

                if (relatorios == null)
                    return NotFound();

                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar relatórios para o município {CodigoIBGE}", codigoIBGE);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet("total-casos-rj-sp")]
        public async Task<IActionResult> GetTotalCasosRioSaoPaulo()
        {
            try
            {
                var resultado = await _relatorioService.ObterTotalCasosRioSaoPauloAsync();
                
                if (resultado == null)
                    return NotFound();  

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar total de casos do Rio de Janeiro e São Paulo");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet("total-por-arbovirose")]
        public async Task<IActionResult> GetTotalCasosPorArbovirose()
        {
            try
            {
                var resultado = await _relatorioService.ObterTotalCasosPorArboviroseAsync();

                if (resultado == null)
                    return NotFound();  

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar total de casos por arbovirose");
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
