namespace DebtsRegisterChallenger.Application.Features.Debts.Commands;

public class CreateDebtCommandHandler(IDebtRepository debtRepository) : IRequestHandler<CreateDebtCommand, Guid>
{
    public async Task<Guid> Handle(CreateDebtCommand command, CancellationToken cancellationToken)
    {
        var debt = command.ToEntity();

        await debtRepository.Add(debt);

        await debtRepository.SaveChanges();

        return debt.Id;
    }
}