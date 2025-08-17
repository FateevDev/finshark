using JetBrains.Annotations;
using LeetCode.Tasks.ArraysAndHashing;

namespace LeetCode.Tests.Tasks.ArraysAndHashing;

[TestSubject(typeof(BestTimeToBuyAndSellStockII))]
public class BestTimeToBuyAndSellStockIITest
{
    [Theory]
    [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 7)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
    public void MaxProfit_WhenCalled_ReturnsExpectedResult(int[] prices, int expected)
    {
        var sut = new BestTimeToBuyAndSellStockII();

        var maxProfit = sut.MaxProfit(prices);

        Assert.Equal(expected, maxProfit);
    }
}