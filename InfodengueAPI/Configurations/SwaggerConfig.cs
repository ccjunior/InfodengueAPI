using Microsoft.OpenApi.Models;

namespace InfodengueAPI.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "InfoDengue API",
                    Version = "v1",
                    Description = "API para consulta de dados epidemiológicos da plataforma INFODENGUE",
                    Contact = new OpenApiContact
                    {
                        Name = "carlos costa junior",
                        Email = "carlos.costajunior@hotmail.com"
                    }
                });

                var xmlFile = "InfoDengueAPI.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
