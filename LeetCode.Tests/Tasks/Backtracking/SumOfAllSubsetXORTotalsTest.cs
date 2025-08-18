using JetBrains.Annotations;
using LeetCode.Tasks.Backtracking;

namespace LeetCode.Tests.Tasks.Backtracking;

[TestSubject(typeof(SumOfAllSubsetXORTotals))]
public class SumOfAllSubsetXORTotalsTest
{
    [Theory]
    [InlineData(new[] { 1, 3 }, 6)]
    [InlineData(new[] { 5, 1, 6 }, 28)]
    [InlineData(new[] { 3, 4, 5, 6, 7, 8 }, 480)]
    public void SubsetXORSum_WhenCalled_ReturnsExpectedResult(int[] nums, int expected)
    {
        var sut = new SumOfAllSubsetXORTotals();

        var result = sut.SubsetXORSum(nums);

        Assert.Equal(expected, result);
    }
}