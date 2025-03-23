using InfodengueAPI.Domain.Models;

namespace InfodengueAPI.Business.Interfaces.Repositories
{
    public interface IRelatorioRepository
    {
        Task AdcionarAsync(Relatorio relatorio);
        Task<IEnumerable<Relatorio>> ObterTodosAsync();
        Task<IEnumerable<Relatorio>> ObterMunicipioCodigoIBGEAsync(string codigoIBGE);
        Task<IEnumerable<Relatorio>> ObterDadosRioSaoPauloAsync();
        Task<IEnumerable<object>> ObterTotalCasosRioSaoPauloAsync();
        Task<IEnumerable<object>> ObterTotalCasosPorArboviroseAsync();
        //Task<IEnumerable<Relatorio>> ObterFiltradoAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose);
    }
}
