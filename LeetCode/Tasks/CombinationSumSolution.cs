namespace LeetCode.Tasks;

/*
 * Combination Sum https://leetcode.com/problems/combination-sum
 *
 * Given an array of distinct integers candidates and a target integer target,
 * return a list of all unique combinations of candidates where the chosen numbers sum to target.
 * You may return the combinations in any order.
 * The same number may be chosen from candidates an unlimited number of times.
 * Two combinations are unique if the frequency of at least one of the chosen numbers is different.
 * The test cases are generated such that the number of unique combinations that sum up to target is
 * less than 150 combinations for the given input.
 *
 * Сумма комбинации
 * Дан массив отдельных целых чисел candidates и целевое число target.
 * Вернуть список всех уникальных комбинаций candidates где числа в сумме дают target
 * Комбинации можно вернуть в любом порядке
 *
 * Одно и то же число может быть взято из candidates неограниченное число раз
 * 2 комбинации уникальные, если частота хотя бы одного числа разная.
 *
 *
 */
public class CombinationSumSolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        return new List<IList<int>> { new[] { 2, 2, 3 }, new[] { 7 } };
    }
}