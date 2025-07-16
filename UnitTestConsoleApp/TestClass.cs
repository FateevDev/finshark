namespace UnitTestConsoleApp;

public class TestClass
{
    public string Pokemon(int num)
    {
        return num switch
        {
            0 => "Pikachu",
            1 => "Bulbasaur",
            2 => "Ivysaur",
            3 => "Venusaur",
            4 => "Charmander",
            5 => "Charmeleon",
            6 => "Charizard",
            7 => "Squirtle",
            8 => "Wartortle",
            9 => "Blastoise",
            10 => "Caterpie",
            _ => "Unknown Pokemon"
        };
    }
}