using InfodengueAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
            .AddDatabase(builder.Configuration)
            .RegisterServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();


var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoDengue API"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
