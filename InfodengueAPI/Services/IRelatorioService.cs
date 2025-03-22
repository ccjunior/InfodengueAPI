using InfodengueAPI.Models;

namespace InfodengueAPI.Services
{
    public interface IRelatorioService
    {
        Task<Relatorio> CreateAsync(string nome, string cpf, string arbovirose, int semanaInicio, int semanaFim, string codigoIBGE);
        Task<IEnumerable<Relatorio>> GetAllAsync();
        Task<Relatorio> GetByIdAsync(int id);
        Task<IEnumerable<Relatorio>> GetByMunicipioCodigoIBGEAsync(string codigoIBGE);
        Task<IEnumerable<Relatorio>> GetDadosRioSaoPauloAsync();
        Task<IEnumerable<object>> GetTotalCasosRioSaoPauloAsync();
        Task<IEnumerable<object>> GetTotalCasosPorArboviroseAsync();
        Task<IEnumerable<Relatorio>> GetFiltradoAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose);
    }
}
