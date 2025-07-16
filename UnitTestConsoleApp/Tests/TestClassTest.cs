namespace UnitTestConsoleApp.Tests;

public class TestClassTest
{
    public static void ItReturnsCorrectPokemon()
    {
        try
        {
            //Arrange
            var sut = new TestClass();
            int num = 0;

            //Act
            var pokemon = sut.Pokemon(num);

            //Assert
            if (pokemon != "Pikachu")
            {
                throw new Exception("FAILED: Pokemon is not Pikachu");
            }

            Console.WriteLine("PASSED");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}