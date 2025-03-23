using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Domain.Dtos;
using Microsoft.Extensions.Logging;

namespace InfodengueAPI.Business.Services
{
    public class InfoDengueService : IInfoDengueService
    {
        private readonly ILogger<InfoDengueService> _logger;

        public InfoDengueService(ILogger<InfoDengueService> logger)
        {
            _logger = logger;
        }

        public async Task<string> ObterDadosEpidemiologicosAsync(RelatorioDto relatorioDto)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://info.dengue.mat.br/api/");
                var response = await client.GetAsync($"alertcity?geocode={relatorioDto.CodigoIBGE}&disease={relatorioDto.Arbovirose}&format=json&ew_start={relatorioDto.SemanaInicio}&ew_end={relatorioDto.SemanaInicio}&ey_start={relatorioDto.AnoInicio}&ey_end={relatorioDto.AnoFim}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar a API INFODENGUE para o município {CodigoIBGE}", relatorioDto.CodigoIBGE);
                throw;
            }
        }

        public async Task<string> ObterDadosMunicipioAsync(string codigoIBGE)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string url = $"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{codigoIBGE}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar dados do município {CodigoIBGE}", codigoIBGE);
                throw;
            }
        }
    }
}
