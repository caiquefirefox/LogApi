using Log.API.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
// Use Serilog
builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration
        .WriteTo.InfluxDB
        (
            applicationName: "Quick test",
            uri: new Uri("http://127.0.0.1:8086"),
            organizationId: "7bdc1205ae4f3259",  // Organization Id - unique id can be found under Profile > About > Common Ids)
            bucketName: "logapi",
            token: "9859DAA6-3B3F-48FE-A981-AE9D31FBB334"
        );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseLogApi();

Serilog.Log.Information("Adding Routes");
app.Logger.LogInformation("Adding Routes");
app.MapControllers();

Serilog.Log.Information("Run app");
app.Logger.LogInformation("Run app");
app.Run();
