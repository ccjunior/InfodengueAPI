using InfodengueAPI.Repositories;
using InfodengueAPI.Repositories.Impl;
using InfodengueAPI.Services.Impl;
using InfodengueAPI.Services;

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
