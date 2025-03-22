using InfodengueAPI.Models;
using InfodengueAPI.Repositories;
using System.Text.Json;

namespace InfodengueAPI.Services.Impl
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly ISolicitanteService _solicitanteService;
        private readonly IInfoDengueService _infoDengueService;
        private readonly ILogger<RelatorioService> _logger;

        public RelatorioService(
            IRelatorioRepository relatorioRepository,
            ISolicitanteService solicitanteService,
            IInfoDengueService infoDengueService,
            ILogger<RelatorioService> logger)
        {
            _relatorioRepository = relatorioRepository;
            _solicitanteService = solicitanteService;
            _infoDengueService = infoDengueService;
            _logger = logger;
        }

        public async Task<Relatorio> CreateAsync(string nome, string cpf, string arbovirose, int semanaInicio, int semanaFim, string codigoIBGE)
        {
            // Verifica/Cria solicitante
            var solicitante = await _solicitanteService.CreateAsync(nome, cpf);

            // Obtém dados do município
            var dadosMunicipio = await _infoDengueService.GetDadosMunicipioAsync(codigoIBGE);
            var municipioInfo = JsonSerializer.Deserialize<JsonElement>(dadosMunicipio);
            string nomeMunicipio = "Desconhecido";

            try
            {
                nomeMunicipio = municipioInfo.GetProperty("nome").GetString();
            }
            catch
            {
                _logger.LogWarning("Não foi possível obter o nome do município para o código {CodigoIBGE}", codigoIBGE);
            }

            // Consulta dados epidemiológicos na API INFODENGUE
            var dadosEpidemiologicos = await _infoDengueService.GetDadosEpidemiologicosAsync(
                codigoIBGE, semanaInicio, semanaFim, arbovirose);

            // Cria o relatório
            var relatorio = new Relatorio
            {
                DataSolicitacao = DateTime.Now,
                Arbovirose = arbovirose,
                SolicitanteId = solicitante.Id,
                SemanaInicio = semanaInicio,
                SemanaFim = semanaFim,
                CodigoIBGE = codigoIBGE,
                Municipio = nomeMunicipio,
                DadosConsulta = dadosEpidemiologicos
            };

            await _relatorioRepository.AddAsync(relatorio);
            await _relatorioRepository.SaveChangesAsync();

            _logger.LogInformation("Relatório criado: {Arbovirose}, Município: {Municipio}", arbovirose, nomeMunicipio);
            return relatorio;
        }

        public async Task<IEnumerable<Relatorio>> GetAllAsync()
        {
            return await _relatorioRepository.GetAllAsync();
        }

        public async Task<Relatorio> GetByIdAsync(int id)
        {
            return await _relatorioRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Relatorio>> GetByMunicipioCodigoIBGEAsync(string codigoIBGE)
        {
            return await _relatorioRepository.GetByMunicipioCodigoIBGEAsync(codigoIBGE);
        }

        public async Task<IEnumerable<Relatorio>> GetDadosRioSaoPauloAsync()
        {
            return await _relatorioRepository.GetDadosRioSaoPauloAsync();
        }

        public async Task<IEnumerable<object>> GetTotalCasosRioSaoPauloAsync()
        {
            return await _relatorioRepository.GetTotalCasosRioSaoPauloAsync();
        }

        public async Task<IEnumerable<object>> GetTotalCasosPorArboviroseAsync()
        {
            return await _relatorioRepository.GetTotalCasosPorArboviroseAsync();
        }

        public async Task<IEnumerable<Relatorio>> GetFiltradoAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose)
        {
            return await _relatorioRepository.GetFiltradoAsync(codigoIBGE, semanaInicio, semanaFim, arbovirose);
        }
    }
}
