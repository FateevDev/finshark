// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
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

Rat rat1 = new Rat();
Rat rat2 = new BigRat();


rat1.Name = "Fred";
rat1.Age = 10;
rat1.IsRadioactive = true;
rat1.Color = "Red";

rat2.Name = "Barney";
rat2.Age = 12;
rat2.IsRadioactive = false;
rat2.Color = "Blue";

Console.WriteLine(rat1.TimeToLive());
Console.WriteLine(rat2.TimeToLive());

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

int GetCurrentYear() {
    var currentDate = DateTime.Now;

    return Convert.ToInt32(currentDate.ToString("yyyy-MM-dd").Substring(0,4));
}