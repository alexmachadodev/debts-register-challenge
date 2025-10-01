namespace DebtsRegisterChallenger.Infrastructure.Persistence.Repositories;

public class DebtRepository(ApplicationDbContext context) : IDebtRepository
{
    public async Task<Debt> Add(Debt debt)
    {
        await context.Debts.AddAsync(debt);

        return debt;
    }

    public async Task<IEnumerable<Debt>> GetAll()
        => await context.Debts
            .AsNoTracking()
            .Include(d => d.Installments)
            .ToListAsync();

    public async Task<bool> SaveChanges() 
        => await context.SaveChangesAsync() > 0;
}