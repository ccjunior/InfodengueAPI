using InfodengueAPI.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Business.Interfaces.Repositories;
using InfodengueAPI.Domain.Dtos;
using InfodengueAPI.Business.Converter;
using System.Collections.Generic;

namespace InfodengueAPI.Business.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly IInfoDengueService _infoDengueService;
        private readonly ILogger<RelatorioService> _logger;

        public RelatorioService(
            IRelatorioRepository relatorioRepository,
            ISolicitanteService solicitanteService,
            IInfoDengueService infoDengueService,
            ILogger<RelatorioService> logger,
            ISolicitanteRepository solicitanteRepository)
        {
            _relatorioRepository = relatorioRepository;
            _infoDengueService = infoDengueService;
            _logger = logger;
            _solicitanteRepository = solicitanteRepository;
        }

        public async Task<ServiceResult<RelatorioResponseDto>> AdcionarAsync(RelatorioRequestDto request)
        {
            var solicitante = await ObterOuCriarSolicitanteAsync(request);

            var nomeMunicipio = await ObterNomeMunicipioAsync(request.CodigoIBGE);

            if (string.IsNullOrEmpty(nomeMunicipio))
            {
                _logger.LogWarning("Não foi possível obter o nome do município para o código {CodigoIBGE}", request.CodigoIBGE);
                return ServiceResult<RelatorioResponseDto>.ErrorResult($"Não foi possível obter o nome do município para o código {request.CodigoIBGE}");
            }

            var relatorioDto = CriarRelatorioDto(request);

            var dadosEpidemiologicos = await ObterDadosEpidemiologicosAsync(relatorioDto);

            var dadosEpidemiologicosJson = JsonSerializer.Deserialize<List<DadosEpidemiologicosDto>>(dadosEpidemiologicos);

            if (dadosEpidemiologicosJson != null && dadosEpidemiologicosJson.Count > 0)
            {
                var relatorio = await SalvarRelatorioAsync(request, solicitante.Id, nomeMunicipio, dadosEpidemiologicos);

                return ServiceResult<RelatorioResponseDto>.SuccessResult(MapToResponseDTO(relatorio));
            }

            _logger.LogInformation("Não foi possivel criar o Relatório:{Arbovirose}, Município: {Municipio}", relatorioDto.Arbovirose, nomeMunicipio);
            return ServiceResult<RelatorioResponseDto>.ErrorResult($"Não foi possivel criar o Relatório:{relatorioDto.Arbovirose}, Município: {nomeMunicipio}");
        }

        public async Task<ServiceResultList<RelatorioResponseDto>> ObterDadosRioSaoPauloAsync()
        {
            var relatorios = await _relatorioRepository.ObterDadosRioSaoPauloAsync();
            return ServiceResultList<RelatorioResponseDto>.SuccessResult(MapToResponseDTOList(relatorios.ToList()));
        }

        public async Task<ServiceResultList<RelatorioResponseDto>> ObterTodos()
        {
            var relatorios = await _relatorioRepository.ObterTodosAsync();
            return ServiceResultList<RelatorioResponseDto>.SuccessResult(MapToResponseDTOList(relatorios.ToList())); 
        }

        public async Task<ServiceResultList<RelatorioResponseDto>> ObterMunicipioCodigoIBGEAsync(string codigoIBGE)
        {
            var relatorios = await _relatorioRepository.ObterMunicipioCodigoIBGEAsync(codigoIBGE);
            return ServiceResultList<RelatorioResponseDto>.SuccessResult(MapToResponseDTOList(relatorios.ToList()));
        }

        public async Task<ServiceResultList<object>> ObterTotalCasosRioSaoPauloAsync()
        {
            var relatorios = await _relatorioRepository.ObterTotalCasosRioSaoPauloAsync();
            return ServiceResultList<object>.SuccessResult(relatorios.ToList());
        }

        public async Task<ServiceResultList<object>> ObterTotalCasosPorArboviroseAsync()
        {
            var relatorios = await _relatorioRepository.ObterTotalCasosPorArboviroseAsync();
            return ServiceResultList<object>.SuccessResult(relatorios.ToList());
        }

        #region Private Methods
        private async Task<Solicitante> ObterOuCriarSolicitanteAsync(RelatorioRequestDto request)
        {
            var solicitante = await _solicitanteRepository.ObterPorCPFAsync(request.CPF);

            if (solicitante == null)
            {
                solicitante = new Solicitante { Nome = request.Nome, CPF = request.CPF };
                solicitante = await _solicitanteRepository.AdcionarAsync(solicitante);
            }

            return solicitante;
        }

        private async Task<string> ObterNomeMunicipioAsync(string codigoIBGE)
        {
            var dadosMunicipio = await _infoDengueService.ObterDadosMunicipioAsync(codigoIBGE);

            try
            {
                var municipioInfo = JsonSerializer.Deserialize<JsonElement>(dadosMunicipio);
                return municipioInfo.GetProperty("nome").GetString();
            }
            catch
            {
                _logger.LogWarning("Não foi possível obter o nome do município para o código {CodigoIBGE}", codigoIBGE);
                return string.Empty;
            }
        }

        private RelatorioDto CriarRelatorioDto(RelatorioRequestDto request)
        {
            return new RelatorioDto
            {
                Nome = request.Nome,
                CPF = request.CPF,
                Arbovirose = request.Arbovirose,
                SemanaInicio = DateConverter.GetWeekOfYear(request.SemanaInicio),
                SemanaFim = DateConverter.GetWeekOfYear(request.SemanaFim),
                CodigoIBGE = request.CodigoIBGE,
                AnoInicio = request.SemanaInicio.Year,
                AnoFim = request.SemanaFim.Year
            };
        }

        private async Task<string> ObterDadosEpidemiologicosAsync(RelatorioDto relatorioDto)
        {
            return await _infoDengueService.ObterDadosEpidemiologicosAsync(relatorioDto);
        }

        private async Task<Relatorio> SalvarRelatorioAsync(RelatorioRequestDto relatorioDto, int solicitanteId, string municipio, string dadosEpidemiologicos)
        {
            var relatorio = new Relatorio
            {
                DataSolicitacao = DateTime.Now,
                Arbovirose = relatorioDto.Arbovirose,
                SolicitanteId = solicitanteId,
                SemanaInicio = relatorioDto.SemanaInicio,
                SemanaFim = relatorioDto.SemanaFim,
                CodigoIBGE = relatorioDto.CodigoIBGE,
                Municipio = municipio,
                DadosConsulta = dadosEpidemiologicos
            };

            await _relatorioRepository.AdcionarAsync(relatorio);
            _logger.LogInformation("Relatório criado: {Arbovirose}, Município: {Municipio}", relatorioDto.Arbovirose, municipio);

            return relatorio;
        }

        private RelatorioResponseDto MapToResponseDTO(Relatorio relatorio)
        {
            return new RelatorioResponseDto
            {
                Id = relatorio.Id,
                NomeSolicitante = relatorio.Solicitante?.Nome,
                DataSolicitacao = relatorio.DataSolicitacao,
                Arbovirose = relatorio.Arbovirose,
                SemanaInicio = relatorio.SemanaInicio,
                SemanaFim = relatorio.SemanaFim,
                CodigoIBGE = relatorio.CodigoIBGE,
                Municipio = relatorio.Municipio,
                Dados = JsonSerializer.Deserialize<dynamic>(relatorio.DadosConsulta)
            };
        }

        private IEnumerable<RelatorioResponseDto> MapToResponseDTOList(List<Relatorio> relatorios)
        {
            return relatorios.Select(relatorio => new RelatorioResponseDto
            {
                Id = relatorio.Id,
                NomeSolicitante = relatorio.Solicitante?.Nome,
                DataSolicitacao = relatorio.DataSolicitacao,
                Arbovirose = relatorio.Arbovirose,
                SemanaInicio = relatorio.SemanaInicio,
                SemanaFim = relatorio.SemanaFim,
                CodigoIBGE = relatorio.CodigoIBGE,
                Municipio = relatorio.Municipio,
                Dados = JsonSerializer.Deserialize<dynamic>(relatorio.DadosConsulta)
            }).ToList();
        }
        #endregion
    }
}
