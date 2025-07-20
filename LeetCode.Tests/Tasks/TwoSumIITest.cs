using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(TwoSumII))]
public class TwoSumIITest
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 15, new[] { 1, 2 })]
    public void TwoSum_WhenCalled_ReturnsArrayOfTwoInts(int[] nums, int target, int[] expected)
    {
    }
}