namespace DebtsRegisterChallenger.Application.Features.Debts.Mappings;

public static class DebtMappers
{
    public static Debt ToEntity(this CreateDebtCommand command)
        => new()
        {
            TitleNumber = command.TitleNumber,
            DebtorName = command.DebtorName,
            DebtorCpf = command.DebtorCpf,
            InterestPercent = command.InterestPercent,
            FinePercent = command.FinePercent,
            Installments = command.Installments.Select(i => new Installment
            {
                InstallmentNumber = i.InstallmentNumber,
                DueDate = i.DueDate,
                Amount = i.Amount
            }).ToList()
        };

    public static DebtSummaryResponse ToSummaryResponse(this Debt debt, DateTime today)
    {
        var updatedValue = Math.Round(debt.GetUpdatedValue(today), 2);

        return new DebtSummaryResponse(
            debt.Id,
            debt.TitleNumber,
            debt.DebtorName,
            debt.Installments.Count,
            debt.GetOriginalValue(),
            debt.GetDaysInArrears(today),
            updatedValue
        );
    }
}