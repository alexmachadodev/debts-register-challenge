namespace DebtsRegisterChallenger.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IDebtRepository).Assembly));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("DebtsDb"));

        services.AddScoped<IDebtRepository, DebtRepository>();

        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}