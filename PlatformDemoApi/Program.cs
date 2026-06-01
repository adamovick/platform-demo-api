var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Platform Demo API is running 🚀");

app.MapGet("/health", () => Results.Ok(new
{
    status = "healthy",
    app = "platform-demo-api",
    version = "v1"
}));

app.MapGet("/version", () => Results.Ok(new
{
    version = "v1",
    environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "unknown"
}));

app.Run();