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
}