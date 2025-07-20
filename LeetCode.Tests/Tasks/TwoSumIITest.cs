using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(TwoSumII))]
public class TwoSumIITest
{
    private readonly TwoSumII _sut = new();

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
    [InlineData(new[] { 2, 3, 4 }, 6, new[] { 1, 3 })]
    [InlineData(new[] { -10, -8, -2, 1, 2, 5, 6 }, 0, new[] { 3, 5 })]
    public void TwoSum_WhenCalled_ReturnsArrayOfTwoInts(int[] nums, int target, int[] expected)
    {
        var twoSum = _sut.TwoSum(nums, target);

        Assert.Equal(expected, twoSum);
    }
}