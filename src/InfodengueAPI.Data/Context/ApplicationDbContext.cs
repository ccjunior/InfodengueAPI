using InfodengueAPI.Data.Mapping;
using InfodengueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfodengueAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SolicitanteMap());
            modelBuilder.ApplyConfiguration(new RelatorioMap());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
