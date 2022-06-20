using BordaAcademy2022.Database;
using BordaAcademy2022.Middlewares;
using BordaAcademy2022.Repositories;

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

    // services.AddSingleton<IStudentRepository, StudentRepository>();

    services.AddScoped<IStudentRepository, RealStudentRepository>();
    services.AddLogging();
    services.AddDbContext<DemoContext>();
}

void ConfigurePipeline(WebApplication app)
{
    app.UseMiddleware<ExceptionHandlerMiddleware>();

    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseRouting();

    app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
    });
}


