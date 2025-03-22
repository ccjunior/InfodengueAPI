using InfodengueAPI.Data;
using InfodengueAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace InfodengueAPI.Repositories.Impl
{
    public class RelatorioRepository : RepositoryBase<Relatorio>, IRelatorioRepository
    {
        public RelatorioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Relatorio>> GetByMunicipioCodigoIBGEAsync(string codigoIBGE)
        {
            return await _dbSet
                .Include(r => r.Solicitante)
                .Where(r => r.CodigoIBGE == codigoIBGE)
                .ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> GetDadosRioSaoPauloAsync()
        {
            return await _dbSet
                .Include(r => r.Solicitante)
                .Where(r => r.CodigoIBGE == "3304557" || r.CodigoIBGE == "3550308")
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetTotalCasosRioSaoPauloAsync()
        {
            var relatorios = await GetDadosRioSaoPauloAsync();

            // Agrupar por município e calcular total
            return relatorios
                .GroupBy(r => r.Municipio)
                .Select(g => new
                {
                    Municipio = g.Key,
                    TotalCasos = g.Sum(r =>
                    {
                        // Tenta extrair o total de casos do JSON armazenado
                        try
                        {
                            var dados = JsonSerializer.Deserialize<JsonElement>(r.DadosConsulta);
                            if (dados.TryGetProperty("cases", out var cases))
                            {
                                return cases.GetInt32();
                            }
                        }
                        catch { }
                        return 0;
                    })
                });
        }

        public async Task<IEnumerable<object>> GetTotalCasosPorArboviroseAsync()
        {
            var relatorios = await _dbSet.ToListAsync();

            return relatorios
                .GroupBy(r => new { r.Arbovirose, r.Municipio })
                .Select(g => new
                {
                    Arbovirose = g.Key.Arbovirose,
                    Municipio = g.Key.Municipio,
                    TotalCasos = g.Sum(r =>
                    {
                        try
                        {
                            var dados = JsonSerializer.Deserialize<JsonElement>(r.DadosConsulta);
                            if (dados.TryGetProperty("cases", out var cases))
                            {
                                return cases.GetInt32();
                            }
                        }
                        catch { }
                        return 0;
                    })
                });
        }

        public async Task<IEnumerable<Relatorio>> GetFiltradoAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose)
        {
            return await _dbSet
                .Include(r => r.Solicitante)
                .Where(r =>
                    r.CodigoIBGE == codigoIBGE &&
                    r.SemanaInicio >= semanaInicio &&
                    r.SemanaFim <= semanaFim &&
                    r.Arbovirose == arbovirose)
                .ToListAsync();
        }
    }
}
