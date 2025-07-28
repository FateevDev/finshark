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
    public void MinSubArrayLen_WhenCalled_ReturnsExpectedResult(int target, int[] nums, int expected)
    {
        var sut = new MinimumSizeSubarraySum();

        var minSubArrayLen = sut.MinSubArrayLen(target, nums);

        Assert.Equal(expected, minSubArrayLen);
    }
}