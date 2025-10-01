namespace DebtsRegisterChallenger.Infrastructure.Services;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime Today => DateTime.Today;
}