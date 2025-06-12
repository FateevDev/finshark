using System.Text.Json;

namespace Sandbox;

public static class JsonSandbox
{
    public static void TestJson()
    {
        var json1 = "[\"params\":[],{\"a\":\"b\"},[1,2,3],[\"a\",\"b\"]]";
        var json2 = "[\'Params\': []]";
        var json3 = "[{\"a\":\"b\"},[1,2,3],[\"a\",\"b\"]]";
        // var json2 =
        // "{ \"0\":{}, \"1\":{\"a\":\"b\"}, \"2\":{\"0\":1, \"1\":2, \"2\":3}, \"3\":{\"0\":\"a\", \"1\":\"b\"} }";

        var metaObjects = JsonSerializer.Deserialize<MetaObject>(json2);
        
        Console.WriteLine(metaObjects);
    }
}

public record MetaObject(string Method, string Account, Dictionary<string, object> Params);