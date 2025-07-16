using JetBrains.Annotations;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.Ping;

[TestSubject(typeof(NetworkService))]
public class NetworkServiceTest
{
    private readonly NetworkService _sut = new();

    [Fact]
    public void Ping_WhenCalled_ReturnsPong()
    {
        var ping = _sut.Ping();

        Assert.Same("pong", ping);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 6, 11)]
    public void ResponseTimeout_WhenCalled_ReturnsSumOfTwoNumbers(int a, int b, int expectedResult)
    {
        var timeout = _sut.ResponseTimeout(a, b);

        Assert.Equal(expectedResult, timeout);
    }

    [Theory]
    [MemberData(nameof(RequestTimeoutData))]
    public void RequestTimeout_WhenCalled_ReturnsSumOfThreeNumbers(int a, int b, int c, int expectedResult)
    {
        var timeout = _sut.RequestTimeout(a, b, c);

        Assert.Equal(expectedResult, timeout);
    }

    public static IEnumerable<object[]> RequestTimeoutData()
    {
        yield return [1, 2, 3, 6];
        yield return [2, 2, 3, 7];
        yield return [3, 2, 3, 8];
    }
}