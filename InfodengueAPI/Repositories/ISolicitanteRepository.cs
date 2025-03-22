using InfodengueAPI.Models;

namespace InfodengueAPI.Repositories
{
    public interface ISolicitanteRepository : IRepositoryBase<Solicitante>
    {
        Task<Solicitante> GetByCPFAsync(string cpf);
    }
}
