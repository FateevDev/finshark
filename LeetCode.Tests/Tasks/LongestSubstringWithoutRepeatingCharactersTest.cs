using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(LongestSubstringWithoutRepeatingCharacters))]
public class LongestSubstringWithoutRepeatingCharactersTest
{
    [Theory]
    [InlineData("asdfaaasdfghff", 6)]
    [InlineData("asdftyaaasdfghff", 6)]
    [InlineData("abcabca", 3)]
    [InlineData("au", 2)]
    public void FindLength_WhenCalled_ReturnsExpectedResult(string s, int expected)
    {
        var sut = new LongestSubstringWithoutRepeatingCharacters();
        
        var result = sut.FindLength(s);
        
        Assert.Equal(expected, result);
    }
}