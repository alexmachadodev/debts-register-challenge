namespace DebtsRegisterChallenger.Api.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Debts Register Challenger API",
                Version = "v1",
                Description = "API for debt registration challenge.",
                Contact = new OpenApiContact
                {
                    Name = "Alex Machado",
                    Email = "alexalvesm@gmail.com"
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
    {
        if (app is WebApplication webApp && webApp.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Debts Register Challenger API v1");
                c.RoutePrefix = string.Empty;
            });
        }

        return app;
    }
}