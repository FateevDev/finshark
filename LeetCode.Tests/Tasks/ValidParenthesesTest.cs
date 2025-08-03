using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(ValidParentheses))]
public class ValidParenthesesTest
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([])", true)]
    [InlineData("([)]", false)]
    [InlineData("]", false)]
    [InlineData("]]]", false)]
    [InlineData("({{{{}}}))", false)]
    [InlineData("([]){", false)]
    public void IsValid_WhenCalled_ReturnsExpectedResults(string s, bool expected)
    {
        var sut = new ValidParentheses();

        var result = sut.IsValid(s);
        
        Assert.Equal(expected, result);
    }
}