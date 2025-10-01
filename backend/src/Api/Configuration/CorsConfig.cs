namespace DebtsRegisterChallenger.Api.Configuration;

public static class CorsConfig
{
    private const string DefaultCorsPolicyName = "DefaultCorsPolicy";

    public static IServiceCollection AddCorsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("CorsSettings:AllowedOrigins").Get<string>();

        services.AddCors(options =>
        {
            options.AddPolicy(name: DefaultCorsPolicyName,
                policy =>
                {
                    if (string.IsNullOrEmpty(allowedOrigins) is false)
                    {
                        policy.WithOrigins(allowedOrigins.Split(';'))
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                });
        });

        return services;
    }

    public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors(DefaultCorsPolicyName);

        return app;
    }
}