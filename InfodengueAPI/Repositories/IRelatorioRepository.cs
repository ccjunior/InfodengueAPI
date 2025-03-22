using InfodengueAPI.Models;

namespace InfodengueAPI.Repositories
{
    public interface IRelatorioRepository : IRepositoryBase<Relatorio>
    {
        Task<IEnumerable<Relatorio>> GetByMunicipioCodigoIBGEAsync(string codigoIBGE);
        Task<IEnumerable<Relatorio>> GetDadosRioSaoPauloAsync();
        Task<IEnumerable<object>> GetTotalCasosRioSaoPauloAsync();
        Task<IEnumerable<object>> GetTotalCasosPorArboviroseAsync();
        Task<IEnumerable<Relatorio>> GetFiltradoAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose);
    }
}
