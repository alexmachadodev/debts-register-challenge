namespace DebtsRegisterChallenger.Application.Abstractions;

public interface IDebtRepository
{
    Task<Debt> Add(Debt debt);
    Task<IEnumerable<Debt>> GetAll();
    Task<bool> SaveChanges();
}