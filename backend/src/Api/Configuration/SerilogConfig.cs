namespace DebtsRegisterChallenger.Api.Configuration;

public static class SerilogConfig
{
    public static WebApplicationBuilder AddSerilogConfig(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console());

        return builder;
    }
}