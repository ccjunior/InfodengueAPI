using InfodengueAPI.Models;

namespace InfodengueAPI.Services
{
    public interface ISolicitanteService
    {
        Task<Solicitante> GetByIdAsync(int id);
        Task<Solicitante> GetByCPFAsync(string cpf);
        Task<IEnumerable<Solicitante>> GetAllAsync();
        Task<Solicitante> CreateAsync(string nome, string cpf);
    }
}
