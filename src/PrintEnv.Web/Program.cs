using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EnvironmentService>();

var app = builder.Build();

app.MapGet("/", (EnvironmentService environmentService) => {
    var env = environmentService.Get();

    var resultBuilder = new StringBuilder();
    foreach(var kv in env)
    {
        resultBuilder.AppendLine($"{kv.Key}={kv.Value}");
    }
    return resultBuilder.ToString();
});
app.MapGet("/api", (EnvironmentService environmentService) => new { environment = environmentService.Get() });

app.Run();



