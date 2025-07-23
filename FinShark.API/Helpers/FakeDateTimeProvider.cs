namespace FinShark.API.Helpers;

public class FakeDateTimeProvider(DateTime dateTime) : IDateTimeProvider
{
    public DateTime UtcNow => dateTime;
}