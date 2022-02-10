using AppServices.MyLogging;
using BaseApi.Api.AppServices;
using BaseApi.Api.AppServices.DataSeed;
using Serilog;

Log.Logger = LoggingExtension.ConfigureLogger();

// Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServiceExtensions(builder.Configuration);

// App
var app = builder.Build();
app.UseServiceExtensions();
app.SeedAplicationData();

try
{
    Log.Information("Application is Starting...");
    app.Run();
    Log.Information("Application is Running...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplication Failed to Start");
}
finally
{
    Log.Information("Application is Shuting Down...");
    Log.CloseAndFlush();
}

