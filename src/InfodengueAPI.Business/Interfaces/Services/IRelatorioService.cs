using InfodengueAPI.Domain.Dtos;

namespace InfodengueAPI.Business.Interfaces.Services
{
    public interface IRelatorioService
    {
        Task<RelatorioResponseDto> AdcionarAsync(RelatorioRequestDto request);
        Task<IEnumerable<RelatorioResponseDto>> ObterTodos();
        Task<IEnumerable<RelatorioResponseDto>> ObterMunicipioCodigoIBGEAsync(string codigoIBGE);
        Task<IEnumerable<RelatorioResponseDto>> ObterDadosRioSaoPauloAsync();
        Task<IEnumerable<object>> ObterTotalCasosRioSaoPauloAsync();
        Task<IEnumerable<object>> ObterTotalCasosPorArboviroseAsync();
    }
}
