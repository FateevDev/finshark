// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using Sandbox;

var helloWorld = "Hello World";
var test = """
           some text
           another string           
           """;
var a = "32000";
var b = @"dfdf/dfdfd\dfdf\dfdf""dfdfd""dfdfdfdfdfdf";
// float b = 12345678910.123456789f;
decimal c = 12345678910.123456789m;
long d = 1234567891012345678;
int e = 1230123478;

dynamic dyn = 1;
object obj = 1;

// App.ArrayCrud();
// App.SwitchExpressions(MyEnum.CodeBlue);


Rat rat1 = new Rat("Fred", 10, "Red", true);
Rat rat2 = new BigRat("Barney", 12, "Blue", false);
Rat rat3 = new("Wilma", 15, "Green", false);
// {
//     Name = "Wilma",
//     Age = 15,
//     IsRadioactive = false,
//     Color = "Green"
// };

rat1.Age = 4444;

ImmutableArray<string> phones = ImmutableArray.Create("123456789", "0987654321");

TestR testR = new("John", "Doe", phones);
TestR testR1 = new("John", "Doe", phones);
TestR testR2 = new("John", "Doe", ImmutableArray.Create("123456789", "0987654321"));
TestR testR3 = testR with { LastName = "Doeken" };
// testR.PhoneNumbers[0] = "5555";

Console.WriteLine(testR == testR1);
Console.WriteLine(testR.Equals(testR1));


Console.WriteLine(testR == testR2);
Console.WriteLine(testR.Equals(testR2));

Console.WriteLine(testR3);

Action tet = ListTest.ListCrud;
var tet1 = (int x) => Console.WriteLine("test" + (x + 3));
Action<int> tet2 = x => { Console.WriteLine("test" + (x + 3)); };

Func<int, string> tet3 = x => "test" + (x + 3);

SuperFunc sf = x => x + 3;


tet();
tet1(1);
tet2(2);
Console.WriteLine(tet3(55));
Console.WriteLine(sf(555));

var list = Enumerable.Range(1, 10).Select(x => x * 2).ToList();

list.ForEach(x => Console.WriteLine(x));

// Console.WriteLine(rat1.TimeToLive());
// Console.WriteLine(rat1.Nickname());
// Console.WriteLine(rat1.Age);
// Console.WriteLine(rat2.TimeToLive());
// Console.WriteLine(rat2.Nickname());
// Console.WriteLine(rat3.TimeToLive());
// Console.WriteLine(rat3.Nickname());

// File.ReadAllText()
// b.StartsWith('+');
// Console.WriteLine(App.ArrayTests());
// Console.WriteLine(b);
// Console.WriteLine();
// Console.WriteLine(8 / 2 + 5 - -3 / 2);
// Console.WriteLine(c);
// var readLine = Console.ReadLine();
// var consoleKeyInfo = Console.ReadKey(true);
// Console.WriteLine("Input: " + readLine);
// Console.WriteLine("Key: " + consoleKeyInfo.KeyChar);

string Text(string an)
{
    an = $"{an} aavv";

    return an;
}

int GetCurrentYear()
{
    var currentDate = DateTime.Now;

    return Convert.ToInt32(currentDate.ToString("yyyy-MM-dd").Substring(0, 4));
}