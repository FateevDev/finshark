namespace LeetCode.Tasks;

/*
 * Best Time to Buy and Sell Stock II https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
 *
 * You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
 * On each day, you may decide to buy and/or sell the stock.
 * You can only hold at most one share of the stock at any time.
 * However, you can buy it then immediately sell it on the same day.
 * Find and return the maximum profit you can achieve.
 *
 * Лучшее время для покупки и продажи акций
 * Дан массив целых чисел цен, где prices[i] - цена акции на i день
 * Каждый день, ты можешь решить, купить или продать акцию.
 * Можно держать только одну акцию в любое время.
 * Однако, можно купить и продать ее в тот же день.
 * Найти и вернуть максимальную прибыль
 *
 * Краткое описание решения:
 * Есть два указателя - левый и правый, указывающие на соседние числа.
 * В цикле сравниваем между собой 2 соседних числа - правое и левое.
 * Если разница со знаком плюс - значит есть прибыль, добавляем ее к финальному результату.
 * Если минус - идем дальше.
 * Сдвигаем указатели, пока не дойдем до конца массива.
 *
 * Сложность:
 * По времени - O(n)
 * По памяти - O(1)
 */
public class BestTimeToBuyAndSellStockII
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            var profit = prices[i] - prices[i - 1];

            if (profit > 0)
            {
                maxProfit += profit;
            }
        }

        return maxProfit;
    }
}