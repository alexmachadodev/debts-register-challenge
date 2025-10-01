namespace DebtsRegisterChallenger.Domain.Entities;

public class Debt
{
    private const int DaysInMonthForInterestCalculation = 30;

    public Guid Id { get; set; }
    public string TitleNumber { get; set; } = string.Empty;
    public string DebtorName { get; set; } = string.Empty;
    public string DebtorCpf { get; set; } = string.Empty;
    public decimal InterestPercent { get; set; }
    public decimal FinePercent { get; set; }

    public ICollection<Installment> Installments { get; set; } = [];

    public decimal GetOriginalValue() => Installments.Sum(i => i.Amount);

    public int GetDaysInArrears(DateTime today)
    {
        var oldestOverdueInstallment = GetOverdueInstallments(today)
            .OrderBy(i => i.DueDate)
            .FirstOrDefault();

        if (oldestOverdueInstallment is null)
            return 0;

        return (int)(today.Date - oldestOverdueInstallment.DueDate.Date).TotalDays;
    }

    public decimal GetUpdatedValue(DateTime today)
    {
        var originalValue = GetOriginalValue();

        if (!IsOverdue(today))
            return originalValue;

        var fine = CalculateFine(originalValue);
        var totalInterest = CalculateTotalInterest(today);

        return originalValue + fine + totalInterest;
    }

    //Verifica se a dívida tem alguma parcela em atraso.
    private bool IsOverdue(DateTime today)
        => Installments.Any(i => i.DueDate.Date < today.Date);

    // Retorna uma coleção de todas as parcelas vencidas.
    private IEnumerable<Installment> GetOverdueInstallments(DateTime today)
        => Installments.Where(i => i.DueDate.Date < today.Date);

    // Calcula o valor da multa com base no valor original da dívida.
    // A multa é aplicada uma única vez.
    private decimal CalculateFine(decimal originalValue)
        => originalValue * (FinePercent / 100);

    //Calcula o valor total dos juros, somando os juros de cada parcela vencida.
    private decimal CalculateTotalInterest(DateTime today)
    {
        var dailyInterestRate = (InterestPercent / 100) / DaysInMonthForInterestCalculation;
        decimal totalInterest = 0;

        var overdueInstallments = GetOverdueInstallments(today);

        foreach (var installment in overdueInstallments)
        {
            var daysOverdue = (int)(today.Date - installment.DueDate.Date).TotalDays;
            totalInterest += installment.Amount * dailyInterestRate * daysOverdue;
        }

        return totalInterest;
    }
}