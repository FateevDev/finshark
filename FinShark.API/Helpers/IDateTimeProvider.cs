namespace FinShark.API.Helpers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}