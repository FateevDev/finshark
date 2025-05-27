// See https://aka.ms/new-console-template for more information

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

Console.WriteLine(rat1.TimeToLive());
Console.WriteLine(rat1.Nickname());
Console.WriteLine(rat2.TimeToLive());
Console.WriteLine(rat2.Nickname());
Console.WriteLine(rat3.TimeToLive());
Console.WriteLine(rat3.Nickname());

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