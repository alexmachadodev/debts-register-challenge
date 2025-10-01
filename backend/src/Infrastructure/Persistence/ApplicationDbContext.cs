namespace DebtsRegisterChallenger.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Debt> Debts { get; set; }
    public DbSet<Installment> Installments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Debt>()
            .HasMany(d => d.Installments)
            .WithOne(i => i.Debt)
            .HasForeignKey(i => i.DebtId);

        base.OnModelCreating(modelBuilder);
    }
}