using InfodengueAPI.Business.Interfaces.Repositories;
using InfodengueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace InfodengueAPI.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private ApplicationDbContext _context;

        public RelatorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdcionarAsync(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Relatorio>> ObterTodosAsync()
        {
            return await _context.Relatorios
                .Include(r => r.Solicitante)
                .ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> ObterMunicipioCodigoIBGEAsync(string codigoIBGE)
        {
            return await _context.Relatorios
                .Include(r => r.Solicitante)
                .Where(r => r.CodigoIBGE == codigoIBGE)
                .ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> ObterDadosRioSaoPauloAsync()
        {
            return await _context.Relatorios
                .Include(r => r.Solicitante)
                .Where(r => r.CodigoIBGE == "3304557" || r.CodigoIBGE == "3550308")
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> ObterTotalCasosRioSaoPauloAsync()
        {
            var relatorios = await ObterDadosRioSaoPauloAsync();

            return relatorios
                .GroupBy(r => new { r.Municipio }) 
                .Select(g => new
                {
                    Municipio = g.Key.Municipio,
                    TotalCasos = g
                        .GroupBy(r => new { r.Arbovirose, r.SemanaInicio, r.SemanaFim }) 
                        .Select(gr => gr.First())
                        .Sum(r =>
                        {
                            try
                            {
                                var dados = JsonSerializer.Deserialize<JsonElement>(r.DadosConsulta);

                                if (dados.ValueKind == JsonValueKind.Array && dados.GetArrayLength() > 0)
                                {
                                    var primeiroObjeto = dados[0];

                                    if (primeiroObjeto.TryGetProperty("casos", out var casos))
                                    {
                                        return casos.ValueKind == JsonValueKind.Number ? casos.GetInt32() : 0;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro ao processar JSON: {ex.Message}");
                            }
                            return 0;
                        })
                })
                .OrderBy(r => r.Municipio);
        }

        public async Task<IEnumerable<object>> ObterTotalCasosPorArboviroseAsync()
        {
            var relatorios = await _context.Relatorios.ToListAsync();

            return relatorios
                .GroupBy(r => new { r.Arbovirose, r.Municipio }) 
                .Select(g => new
                {
                    g.Key.Municipio,
                    g.Key.Arbovirose,
                    TotalCasos = g
                        .DistinctBy(r => new { r.SemanaInicio, r.SemanaFim, r.DadosConsulta }) 
                        .Sum(r =>
                        {
                            try
                            {
                                var dados = JsonSerializer.Deserialize<JsonElement>(r.DadosConsulta);

                                if (dados.ValueKind == JsonValueKind.Array && dados.GetArrayLength() > 0)
                                {
                                    var primeiroObjeto = dados[0];

                                    if (primeiroObjeto.TryGetProperty("casos", out var casos))
                                    {
                                        return casos.ValueKind == JsonValueKind.Number ? casos.GetInt32() : 0;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro ao processar JSON: {ex.Message}");
                            }
                            return 0;
                        })
                });
        }
    }
}
