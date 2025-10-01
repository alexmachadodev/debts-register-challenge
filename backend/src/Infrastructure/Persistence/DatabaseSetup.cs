namespace DebtsRegisterChallenger.Infrastructure.Persistence;

public static class DatabaseSetup
{
    public static async Task SetupDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.IsInMemory())
        {
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}