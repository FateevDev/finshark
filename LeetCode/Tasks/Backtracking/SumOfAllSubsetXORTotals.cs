namespace LeetCode.Tasks.Backtracking;

/*
 * Sum of All Subset XOR Totals
 * https://leetcode.com/problems/sum-of-all-subset-xor-totals/description/
 *
 * The XOR total of an array is defined as the bitwise XOR of all its elements, or 0 if the array is empty.
 * For example, the XOR total of the array [2,5,6] is 2 XOR 5 XOR 6 = 1.
 * Given an array nums, return the sum of all XOR totals for every subset of nums.
 * Note: Subsets with the same elements should be counted multiple times.
 * An array a is a subset of an array b if a can be obtained from b by deleting some (possibly zero) elements of b.
 *
 * Сложность:
 * По времени: O(2^n) - на каждом уровне рекурсии делаем 2 операции - (включить/не включить) - итого 2^3 = 8
 * По памяти: O(n) - глубина рекурсии - 3, т.е. длина массива
 *
 * Массив 5, 1, 6
 * Нужно найти все подмножества
 * На каждом шаге мы считаем сумму с включенным элементом подмножества и без него
 *
 *                          Начало
 *                 /                    \
 *                5                      -
 *              /   \                  /    \
 *             1      -               1      -
 *           /  \    /   \           /   \   /  \
 *          6    -  6     -         6     - 6    -
 *     {5,1,6} {5,1} {5,6} {5}   {1,6}  {1} {6}  {}
 *
 */
public class SumOfAllSubsetXORTotals
{
    public int SubsetXORSum(int[] nums)
    {
        return Backtracking(nums, 0, 0);
    }

    private int Backtracking(int[] nums, int index, int total)
    {
        if (index == nums.Length)
        {
            return total;
        }

        var include = Backtracking(nums, index + 1, total ^ nums[index]);
        var notInclude = Backtracking(nums, index + 1, total);

        return include + notInclude;
    }
}