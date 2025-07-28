using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(MinimumSizeSubarraySum))]
public class MinimumSizeSubarraySumTest
{
    [Theory]
    [InlineData(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
    [InlineData(4, new[] { 1, 4, 4 }, 1)]
    [InlineData(11, new[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0)]
    [InlineData(8, new[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 8)]
    [InlineData(80, new[] { 10, 5, 13, 4, 8, 4, 5, 11, 14, 9, 16, 10, 20, 8 }, 6)]
    [InlineData(6, new[] { 10, 2, 3 }, 1)]
    public void MinSubArrayLen_WhenCalled_ReturnsExpectedResult(int target, int[] nums, int expected)
    {
        var sut = new MinimumSizeSubarraySum();

        var minSubArrayLen = sut.MinSubArrayLen(target, nums);

        Assert.Equal(expected, minSubArrayLen);
    }
}