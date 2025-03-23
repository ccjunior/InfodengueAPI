using InfodengueAPI.Domain.Dtos;

namespace InfodengueAPI.Business.Interfaces.Services
{
    public interface IInfoDengueService
    {
        Task<string> ObterDadosEpidemiologicosAsync(RelatorioDto relatorioDto);
        Task<string> ObterDadosMunicipioAsync(string codigoIBGE);
    }
}
