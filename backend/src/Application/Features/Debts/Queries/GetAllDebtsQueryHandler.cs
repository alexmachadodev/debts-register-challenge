namespace DebtsRegisterChallenger.Application.Features.Debts.Queries;

public class GetAllDebtsQueryHandler(IDebtRepository debtRepository, IDateTimeProvider dateTimeProvider) : IRequestHandler<GetAllDebtsQuery, IEnumerable<DebtSummaryResponse>>
{
    public async Task<IEnumerable<DebtSummaryResponse>> Handle(GetAllDebtsQuery command, CancellationToken cancellationToken)
    {
        var today = dateTimeProvider.Today;
        //var today = Convert.ToDateTime("21/09/2020");

        var debts = await debtRepository.GetAll();

        return debts.Select(debt => debt.ToSummaryResponse(today));
    }
}