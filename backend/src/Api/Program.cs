Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting the application...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddSerilogConfig();
    builder.Services.AddAppServices();
    builder.Services.AddSwaggerConfig();
    builder.Services.AddCorsConfig(builder.Configuration);

    var app = builder.Build();

    await app.Services.SetupDatabaseAsync();

    app.UseSerilogRequestLogging();
    app.UseSwaggerConfig();
    app.UseHttpsRedirection();

    app.UseCorsConfig();

    app.MapDebitEndpoints();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start.");
}
finally
{
    Log.CloseAndFlush();
}
