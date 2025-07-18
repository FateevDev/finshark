using System.Net.NetworkInformation;
using FakeItEasy;
using JetBrains.Annotations;
using NetworkUtility.DNS;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.Ping;

[TestSubject(typeof(NetworkService))]
public class NetworkServiceTest
{
    private readonly NetworkService _sut;
    private readonly IDNS _dns;

    public NetworkServiceTest()
    {
        _dns = A.Fake<IDNS>();

        _sut = new NetworkService(_dns);
    }

    [Fact]
    public void Ping_WhenCalled_ReturnsPong()
    {
        A.CallTo(() => _dns.SendDNS()).Returns(true);

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

    [Fact]
    public void GetPingDateTime_WhenCalled_ReturnsCurrentDateTime()
    {
        var dateTime = _sut.GetPingDateTime();

        Assert.InRange(dateTime, DateTime.Now.AddSeconds(-1), DateTime.Now.AddSeconds(1));
    }

    [Fact]
    public void GetPingOptions_WhenCalled_ReturnsPingOptions()
    {
        var expected = new PingOptions(100, true);

        var pingOptions = _sut.GetPingOptions();

        Assert.IsType<PingOptions>(pingOptions);
        Assert.Equivalent(expected, pingOptions);
    }

    [Fact]
    public void MostRecentPings_WhenCalled_ReturnsListOfPingOptions()
    {
        var recentPings = _sut.MostRecentPings();
    }
}