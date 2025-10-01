namespace DebtsRegisterChallenger.UnitTests.Domain.Entities;

public class DebtTests
{
    [Fact(DisplayName = nameof(GetOriginalValue_ShouldReturnCorrectSumOfInstallments))]
    public void GetOriginalValue_ShouldReturnCorrectSumOfInstallments()
    {
        // Arrange
        var debt = new Debt
        {
            Installments = 
            {
                new Installment { Amount = 150.50m },
                new Installment { Amount = 50.25m },
                new Installment { Amount = 100.00m }
            }
        };
        
        const decimal expectedValue = 300.75m;

        // Act
        var originalValue = debt.GetOriginalValue();

        // Assert
        originalValue.Should().Be(expectedValue);
    }

    [Fact(DisplayName = nameof(GetUpdatedValue_WhenAllInstallmentsAreOverdue_ShouldCalculateCorrectFineAndInterest))]
    public void GetUpdatedValue_WhenAllInstallmentsAreOverdue_ShouldCalculateCorrectFineAndInterest()
    {
        // Arrange
        var today = new DateTime(2020, 9, 21);
        var debt = new Debt
        {
            TitleNumber = "101010",
            DebtorName = "Fulano",
            InterestPercent = 1,
            FinePercent = 2,
            Installments = new List<Installment>
            {
                new() { Amount = 100.00m, DueDate = new DateTime(2020, 7, 10) }, // 73
                new() { Amount = 100.00m, DueDate = new DateTime(2020, 8, 10) }, // 42
                new() { Amount = 100.00m, DueDate = new DateTime(2020, 9, 10) }  // 11
            }
        };

        // Act
        var originalValue = debt.GetOriginalValue();
        var daysInArrears = debt.GetDaysInArrears(today);
        var updatedValue = debt.GetUpdatedValue(today);

        // Assert
        originalValue.Should().Be(300.00m);
        daysInArrears.Should().Be(73);

        updatedValue.Should().BeApproximately(310.20m, 0.01m);
    }

    [Fact(DisplayName = nameof(GetUpdatedValue_WhenNoInstallmentsAreOverdue_ShouldReturnOriginalValue))]
    public void GetUpdatedValue_WhenNoInstallmentsAreOverdue_ShouldReturnOriginalValue()
    {
        // Arrange
        var today = new DateTime(2025, 1, 1);
        var debt = new Debt
        {
            FinePercent = 2,
            InterestPercent = 1,
            Installments = new List<Installment>
            {
                new() { Amount = 200, DueDate = today.AddMonths(1) },
                new() { Amount = 200, DueDate = today.AddMonths(2) }
            }
        };

        // Act
        var daysInArrears = debt.GetDaysInArrears(today);
        var updatedValue = debt.GetUpdatedValue(today);

        // Assert
        daysInArrears.Should().Be(0);
        updatedValue.Should().Be(debt.GetOriginalValue());
        updatedValue.Should().Be(400);
    }

    [Fact(DisplayName = nameof(GetUpdatedValue_WhenSomeInstallmentsAreOverdue_ShouldCalculateCorrectly))]
    public void GetUpdatedValue_WhenSomeInstallmentsAreOverdue_ShouldCalculateCorrectly()
    {
        // Arrange
        var today = new DateTime(2025, 2, 15); // 15/02/2025
        var debt = new Debt
        {
            FinePercent = 10,
            InterestPercent = 3,
            Installments = new List<Installment>
            {
                new() { Amount = 500, DueDate = new DateTime(2025, 1, 10) }, //36
                new() { Amount = 500, DueDate = new DateTime(2025, 3, 10) }
            }
        };
        // Cálculo esperado:
        // Valor Original = 1000
        // Multa (sobre o total) = 1000 * 10% = 100
        // Juros (apenas sobre a parcela vencida) = 500 * (3% / 30) * 36 dias = 18
        // Valor Total = 1000 + 100 + 18 = 1118
        var expectedValue = 1118.00m;

        // Act
        var updatedValue = debt.GetUpdatedValue(today);

        // Assert
        updatedValue.Should().Be(expectedValue);
    }
}