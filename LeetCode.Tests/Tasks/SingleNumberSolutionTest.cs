using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(SingleNumberSolution))]
public class SingleNumberSolutionTest
{
    [Theory]
    [InlineData(new[] { 2, 2, 1 }, 1)]
    [InlineData(new[] { 4, 1, 2, 1, 2 }, 4)]
    [InlineData(new[] { 1 }, 1)]
    public void SingleNumber_WhenCalled_ReturnsExpectedResult(int[] nums, int expected)
    {
        var sut = new SingleNumberSolution();

        var result = sut.SingleNumber(nums);

        Assert.Equal(expected, result);
    }
}