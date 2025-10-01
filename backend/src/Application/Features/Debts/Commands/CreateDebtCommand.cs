namespace DebtsRegisterChallenger.Application.Features.Debts.Commands;

public record CreateDebtCommand(
    string TitleNumber,
    string DebtorName,
    string DebtorCpf,
    decimal InterestPercent,
    decimal FinePercent,
    List<InstallmentRequest> Installments
) : IRequest<Guid>;

public record InstallmentRequest(
    int InstallmentNumber,
    DateTime DueDate,
    decimal Amount
);  