using System.Net.NetworkInformation;

namespace NetworkUtility.Ping;

public class NetworkService
{
    public string Ping()
    {
        return "pong";
    }

    public int ResponseTimeout(int a, int b)
    {
        return a + b;
    }

    public int RequestTimeout(int a, int b, int c)
    {
        return a + b + c;
    }

    public DateTime GetPingDateTime()
    {
        return DateTime.Now;
    }

    public PingOptions GetPingOptions()
    {
        return new PingOptions(100, true);
    }

    public IEnumerable<PingOptions> MostRecentPings()
    {
        return new List<PingOptions>
        {
            new(100, true),
            new(200, false),
            new(300, true)
        };
    }
}