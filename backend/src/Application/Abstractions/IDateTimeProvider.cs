namespace DebtsRegisterChallenger.Application.Abstractions;

public interface IDateTimeProvider
{
    DateTime Today { get; }
}