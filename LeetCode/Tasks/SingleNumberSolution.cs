namespace LeetCode.Tasks;

/*
 * Single Number https://leetcode.com/problems/single-number/description/?source=submission-noac
 *
 * Given a non-empty array of integers nums, every element appears twice except for one.
 * Find that single one.
 * You must implement a solution with a linear runtime complexity and use only constant extra space.
 *
 * Одно число
 * Дан непустой массив целых чисел, каждый элемент встречается дважды за исключением одного.
 * Найти этот один элемент.
 * Решение должно быть линейной сложности по времени и константой по памяти.
 *
 * Краткое описание решения:
 * Решить задачу, не нарушая ограничений, можно только через XOR (исключающее или).
 * Работает - только для различающихся битов дает 1, для совпадающих - 0
 *
 * Т.е. применяя XOR к массиву, мы сначала добавляем числа к результату, а если встретится похоже - исключаем его.
 *
 * Сложность -
 * по времени - O(n)
 * по памяти - O(1)
 */
public class SingleNumberSolution
{
    public int SingleNumber(int[] nums)
    {
        var result = 0;

        foreach (var num in nums)
        {
            result ^= num;
        }

        return result;
    }
}