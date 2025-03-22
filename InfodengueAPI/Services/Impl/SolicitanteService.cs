using InfodengueAPI.Models;
using InfodengueAPI.Repositories;

namespace InfodengueAPI.Services.Impl
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly ILogger<SolicitanteService> _logger;

        public SolicitanteService(ISolicitanteRepository solicitanteRepository, ILogger<SolicitanteService> logger)
        {
            _solicitanteRepository = solicitanteRepository;
            _logger = logger;
        }

        public async Task<Solicitante> GetByIdAsync(int id)
        {
            return await _solicitanteRepository.GetByIdAsync(id);
        }

        public async Task<Solicitante> GetByCPFAsync(string cpf)
        {
            return await _solicitanteRepository.GetByCPFAsync(cpf);
        }

        public async Task<IEnumerable<Solicitante>> GetAllAsync()
        {
            return await _solicitanteRepository.GetAllAsync();
        }

        public async Task<Solicitante> CreateAsync(string nome, string cpf)
        {
            var solicitanteExistente = await _solicitanteRepository.GetByCPFAsync(cpf);
            if (solicitanteExistente != null)
            {
                return solicitanteExistente;
            }

            var novoSolicitante = new Solicitante
            {
                Nome = nome,
                CPF = cpf
            };

            await _solicitanteRepository.AddAsync(novoSolicitante);
            await _solicitanteRepository.SaveChangesAsync();

            _logger.LogInformation("Solicitante criado: {Nome}, CPF: {CPF}", nome, cpf);
            return novoSolicitante;
        }
    }
}
