using InfodengueAPI.Domain.Dtos;
using InfodengueAPI.Domain.Models;

namespace InfodengueAPI.Business.Interfaces.Services
{
    public interface ISolicitanteService
    {
        Task<IEnumerable<SolicitanteDTO>> ObterTodosAsync();
    }
}
