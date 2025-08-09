using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(LongestRepeatingCharacterReplacement))]
public class LongestRepeatingCharacterReplacementTest
{
    [Theory]
    [InlineData("ABAB", 2, 4)]
    [InlineData("ABAB", 0, 1)]
    [InlineData("AABABBA", 1, 4)]
    [InlineData("ABDD", 2, 4)]
    [InlineData("ABAA", 0, 2)]
    [InlineData("ABC", 1, 2)]
    public void CharacterReplacement_WhenCalled_ReturnsExpectedResult(string s, int k, int expected)
    {
        var sut = new LongestRepeatingCharacterReplacement();

        var characterReplacement = sut.CharacterReplacement(s, k);

        Assert.Equal(expected, characterReplacement);
    }
}