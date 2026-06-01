var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var version = "v3";
var commitSha = Environment.GetEnvironmentVariable("APP_COMMIT_SHA") ?? "unknown";
var buildTime = Environment.GetEnvironmentVariable("APP_BUILD_TIME") ?? "unknown";

app.MapGet("/", () => Results.Content($"""
<!DOCTYPE html>
<html>
<head>
    <title>Adem Koylu Platform Lab</title>
</head>
<body style="font-family: Arial; margin:40px;">
    <h1>?? Adem Koylu Platform Lab</h1>

    <p>Senior Cloud & Platform Engineer</p>

    <h2>Current Stack</h2>
    <ul>
        <li>Kubernetes</li>
        <li>ArgoCD</li>
        <li>GitHub Actions</li>
        <li>GitOps</li>
        <li>NGINX Ingress</li>
        <li>Azure</li>
    </ul>

    <h2>Project Status</h2>
    <p>Healthy ?</p>

    <h2>Release</h2>
    <p>Version: {version}</p>
    <p>Commit: {commitSha}</p>
    <p>Build Time: {buildTime}</p>
</body>
</html>
""", "text/html"));

app.MapGet("/about", () => Results.Ok(new
{
    name = "Adem Koylu",
    role = "Senior Cloud & Platform Engineer",
    project = "Platform Engineering Lab",
    focus = "GitOps, Kubernetes, Azure, Automation"
}));

app.MapGet("/health", () => Results.Ok(new
{
    status = "healthy",
    app = "platform-demo-api",
    version = version
}));

app.MapGet("/version", () => Results.Ok(new
{
    version = version,
    environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "unknown",
    commitSha = commitSha,
    buildTime = buildTime
}));

app.Run();
