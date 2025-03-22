namespace InfodengueAPI.Services.Impl
{
    public class InfoDengueService : IInfoDengueService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<InfoDengueService> _logger;

        public InfoDengueService(HttpClient httpClient, ILogger<InfoDengueService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://info.dengue.mat.br/services/api/");
            _logger = logger;
        }

        public async Task<string> GetDadosEpidemiologicosAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose)
        {
            try
            {
                var response = await _httpClient.GetAsync($"alertcity?geocode={codigoIBGE}&disease={arbovirose}&format=json&ew_start={semanaInicio}&ew_end={semanaFim}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar a API INFODENGUE para o município {CodigoIBGE}", codigoIBGE);
                throw;
            }
        }

        public async Task<string> GetDadosMunicipioAsync(string codigoIBGE)
        {
            try
            {
                var response = await _httpClient.GetAsync($"municipio?geocode={codigoIBGE}");
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
