namespace DebtsRegisterChallenger.Api.Endpoints;

public static class DebitEndpoints
{
    public static IEndpointRouteBuilder MapDebitEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/debts")
            .WithTags("Debts");

        group.MapPost("/", async (CreateDebtCommand command, IMediator mediator) =>
            {
                var debtId = await mediator.Send(command);
                return Results.Created($"/api/debts/{debtId}", new { id = debtId });
            })
            .WithName("CreateDebt")
            .Produces<object>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        group.MapGet("/", async (IMediator mediator) =>
            {
                var debts = await mediator.Send(new GetAllDebtsQuery());
                return Results.Ok(debts);
            })
            .WithName("GetAllDebts")
            .Produces<IEnumerable<DebtSummaryResponse>>();

        return builder;
    }
}