using InfodengueAPI.Business.Services;
using InfodengueAPI.Domain.Dtos;

namespace InfodengueAPI.Business.Interfaces.Services
{
    public interface IRelatorioService
    {
        Task<ServiceResult<RelatorioResponseDto>> AdcionarAsync(RelatorioRequestDto request);
        Task<ServiceResultList<RelatorioResponseDto>> ObterTodos();
        Task<ServiceResultList<RelatorioResponseDto>> ObterMunicipioCodigoIBGEAsync(string codigoIBGE);
        Task<ServiceResultList<RelatorioResponseDto>> ObterDadosRioSaoPauloAsync();
        Task<ServiceResultList<object>> ObterTotalCasosRioSaoPauloAsync();
        Task<ServiceResultList<object>> ObterTotalCasosPorArboviroseAsync();
    }
}
