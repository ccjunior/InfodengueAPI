using InfodengueAPI.Data;
using InfodengueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InfodengueAPI.Repositories.Impl
{
    public class SolicitanteRepository : RepositoryBase<Solicitante>, ISolicitanteRepository
    {
        public SolicitanteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Solicitante> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.CPF == cpf);
        }
    }
}
