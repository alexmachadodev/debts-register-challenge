namespace DebtsRegisterChallenger.Application.Features.Debts.Queries;

public record GetAllDebtsQuery : IRequest<IEnumerable<DebtSummaryResponse>>;

public record DebtSummaryResponse(
    Guid Id,
    string TitleNumber,
    string DebtorName,
    int InstallmentCount,
    decimal OriginalValue,
    int DaysInArrears,
    decimal UpdatedValue
);