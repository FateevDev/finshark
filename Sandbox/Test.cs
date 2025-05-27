namespace Sandbox;

enum MyEnum
{
    CodeRed,
    CodeBlue = 5,
    CodeGreen
}

class App
{
    public static string MultiplyNumbersFromRange(string str)
    {
        var encryptedString = "";
        var i = 0;
        var strLength = str.Length;

        while (i < strLength)
        {
            var encryptedPart = "";

            if ((i + 1) % 2 == 0)
            {
                encryptedPart = str[i].ToString() + str[i - 1].ToString();
            }

            if (strLength % 2 != 0 && i == strLength - 1)
            {
                encryptedPart = str[i].ToString();
            }

            encryptedString += encryptedPart;
            i++;
        }

        return encryptedString;
    }

    public static string MultiplyNumbersFromRange1(string str)
    {
        var encryptedString = "";
        var strLength = str.Length;

        for (int i = 0; i < strLength; i += 2)
        {
            if (i == strLength - 1)
            {
                encryptedString += str[i].ToString();
            }
            else
            {
                encryptedString += str[i + 1].ToString() + str[i].ToString();
            }
        }

        return encryptedString;
    }

    public static void ArrayCrud()
    {
        // Create
        string[] rats = ["fancy", "brown", "yellow"];

        // Read
        // foreach (var rat in rats)
        // {
        //     Console.WriteLine(rat);
        // }

        // Update
        // rats[0] = "bancy";

        // LINQ
        var enumerable = rats.Where((string rat) => rat.StartsWith("f"));

        enumerable.ToList().ForEach(rat =>
        {
            Console.WriteLine(rat);
            Console.WriteLine(rat + "!");
        });
        // Array.ForEach(rats, rat => Console.WriteLine(rat));
        Array.ForEach(rats, rat => Console.WriteLine(rat));

        foreach (var rat in rats)
        {
            Console.WriteLine(rat);
        }
    }

    public static void ForTest(MyEnum myEnum)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine((int)myEnum + ": " + myEnum);
        }
    }

    public static void SwitchExpressions(MyEnum myEnum)
    {
        string result = myEnum switch
        {
            MyEnum.CodeRed or MyEnum.CodeGreen => "Red",
            MyEnum.CodeBlue => "Blue",
            _ => "Unknown"
        };

        Console.WriteLine(result);
    }
}

class TupleTest
{
    public static void Main()
    {
        (int First, string, char) tuple = (First: 1, "2ll", 'l');

        Console.WriteLine(tuple);
        Console.WriteLine(tuple.First);
        Console.WriteLine(tuple.Item2);
        Console.WriteLine(Test());
        Console.WriteLine(Test().second);

        (int a, string b) = Test();
        Console.WriteLine(b);
    }

    public static (int, string second) Test()
    {
        return (1, "2ll111");
    }
}

class NullTest
{
    public static void Main()
    {
        int? a = null;
        string? str = null;
        string str1 = null;
        string str2 = null!;
        Console.WriteLine(str?.Length);
        Console.WriteLine(str ?? "test");
        Console.WriteLine(a);

        if (str1 != null)
        {
            Console.WriteLine(str1.Length);
        }
    }
}