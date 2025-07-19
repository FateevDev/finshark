using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(MergeSortedArrays))]
public class MergeSortedArraysTest
{
    private readonly MergeSortedArrays _sut = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
    [InlineData(new[] { 3, 7, 8, 0, 0, 0 }, 3, new[] { 1, 2, 3 }, 3, new[] { 1, 2, 3, 3, 7, 8 })]
    [InlineData(new[] { 3, 7, 8, 0, 0, 0 }, 3, new[] { 1, 2, 8 }, 3, new[] { 1, 2, 3, 7, 8, 8 })]
    [InlineData(new[] { 1, 5, 99, 100, 0, 0, 0 }, 4, new[] { 1, 50, 89 }, 3, new[] { 1, 1, 5, 50, 89, 99, 100 })]
    public void Merge_WhenCalled_Returns_MergedArray(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        _sut.Merge(nums1, m, nums2, n);

        Assert.Equal(expected, nums1);
    }
}