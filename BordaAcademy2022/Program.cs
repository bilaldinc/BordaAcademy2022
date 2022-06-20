var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

ConfigurePipeline(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void ConfigurePipeline(WebApplication app)
{
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseRouting();

    app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
    });
}


