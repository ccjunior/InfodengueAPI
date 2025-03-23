using InfodengueAPI.Business.Interfaces.Repositories;
using InfodengueAPI.Business.Interfaces.Services;
using InfodengueAPI.Business.Services;
using InfodengueAPI.Data.Repositories;

namespace InfodengueAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();

            //Services
            services.AddScoped<IInfoDengueService, InfoDengueService>();
            services.AddScoped<ISolicitanteService, SolicitanteService>();
            services.AddScoped<IRelatorioService, RelatorioService>();

            //outros
            services.AddHttpClient();
        }
    }
}
