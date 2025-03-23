using InfodengueAPI.Business.Interfaces.Repositories;
using InfodengueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfodengueAPI.Data.Repositories
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly ApplicationDbContext _context;

        public SolicitanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitante> ObterPorCPFAsync(string cpf)
        {
            return await _context.Solicitantes
                .FirstOrDefaultAsync(s => s.CPF == cpf);
        }

        public async Task<Solicitante> AdcionarAsync(Solicitante solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            await _context.SaveChangesAsync();
            return solicitante;
        }

        public async Task<IEnumerable<Solicitante>> ObterTodosAsync()
        {
            return await _context.Solicitantes.ToListAsync();
        }
    }
}
