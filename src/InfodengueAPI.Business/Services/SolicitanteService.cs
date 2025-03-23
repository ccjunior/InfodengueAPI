using InfodengueAPI.Business.Interfaces.Repositories;
using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Domain.Dtos;
using InfodengueAPI.Domain.Models;

namespace InfodengueAPI.Business.Services
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _solicitanteRepository;

        public SolicitanteService(ISolicitanteRepository solicitanteRepository)
        {
            _solicitanteRepository = solicitanteRepository;
        }
       
        public async Task<IEnumerable<SolicitanteDTO>> ObterTodosAsync()
        {
            var solicitantes = await _solicitanteRepository.ObterTodosAsync();
            return MapToResponseDTOList(solicitantes.ToList());
        }

        private IEnumerable<SolicitanteDTO> MapToResponseDTOList(List<Solicitante> solicitantes)
        {
            return solicitantes.Select(solicitante => new SolicitanteDTO
            {
                Nome = solicitante.Nome,
                CPF = solicitante.CPF,
            }).ToList();
        }
    }
}
