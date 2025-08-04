using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(RemoveDuplicatesFromSortedArray))]
public class RemoveDuplicatesFromSortedArrayTest
{
    [Theory]
    [InlineData(new[] { 1, 1, 2 }, new[] { 1, 2, 0 }, 2)]
    [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4, 0, 0, 0, 0, 0 }, 5)]
    [InlineData(new[] { 1 }, new[] { 1 }, 1)]
    [InlineData(new[] { 1, 1 }, new[] { 1 }, 1)]
    public void RemoveDuplicates0WhenCalled0ReturnsExpectedResult(int[] nums, int[] output, int expected)
    {
        var sut = new RemoveDuplicatesFromSortedArray();

        var result = sut.RemoveDuplicates(nums);

        Assert.Equal(expected, result);

        for (var i = 0; i < result; i++)
        {
            Assert.Equal(output[i], nums[i]);
        }
    }
}