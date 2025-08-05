using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(ValidPalindrome))]
public class ValidPalindromeTest
{
    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData("  ", true)]
    public void IsPalindrome_WhenCalled_ReturnExpectedResult(string s, bool expected)
    {
        var sut = new ValidPalindrome();

        var result = sut.IsPalindrome(s);

        Assert.Equal(expected, result);
    }
}