var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Path}");
    Console.WriteLine($"{context.Request.Method}");
    Console.WriteLine($"{context.Request.Protocol}");
    await next();
});

app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Path}");
    Console.WriteLine("First middleware starts");
    await next();
    Console.WriteLine("First middleware ends");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Second middleware starts");
    await next();
    Console.WriteLine("Second middleware ends");
});

app.Run();
