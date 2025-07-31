using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(IntegerToRoman))]
public class IntegerToRomanTest
{

    [Theory]
    [InlineData(3749, "MMMDCCXLIX")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void IntToRoman_WhenCalled_ReturnsExpectedResult(int num, string expected)
    {
        var sut = new IntegerToRoman();
        
        var result = sut.IntToRoman(num);
        
        Assert.Equal(expected, result);
    }
}