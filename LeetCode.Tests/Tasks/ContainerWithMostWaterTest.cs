using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(ContainerWithMostWater))]
public class ContainerWithMostWaterTest
{
    [Theory]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new[] { 1, 1 }, 1)]
    [InlineData(new[] { 1, 8, 1, 1, 1, 4, 1 }, 16)]
    [InlineData(new[] { 1, 8, 4, 1, 1, 1, 1 }, 6)]
    public void MaxArea_WhenCalled_ReturnsExpectedResult(int[] height, int expected)
    {
        var sut = new ContainerWithMostWater();

        var result = sut.MaxArea(height);

        Assert.Equal(expected, result);
    }
}