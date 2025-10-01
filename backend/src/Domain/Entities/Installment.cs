namespace DebtsRegisterChallenger.Domain.Entities;

public class Installment
{
    public Guid Id { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }

    public Guid DebtId { get; set; }
    public Debt Debt { get; set; } = null!;
}