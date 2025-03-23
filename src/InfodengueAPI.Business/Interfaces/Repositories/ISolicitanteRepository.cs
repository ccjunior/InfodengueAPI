using InfodengueAPI.Domain.Models;

namespace InfodengueAPI.Business.Interfaces.Repositories
{
    public interface ISolicitanteRepository
    {
        Task<IEnumerable<Solicitante>> ObterTodosAsync();
        Task<Solicitante> ObterPorCPFAsync(string cpf);
        Task<Solicitante> AdcionarAsync(Solicitante solicitante);
    }
}
