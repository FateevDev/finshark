namespace LeetCode.Tasks;

/*
 * Minimum Size Subarray Sum https://leetcode.com/problems/minimum-size-subarray-sum/description/
 *
 * Given an array of positive integers nums and a positive integer target,
 * return the minimal length of a subarray whose sum is greater than or equal to target.
 * If there is no such subarray, return 0 instead.
 *
 * Дан массив положительных целых чисел nums и положительное целое число target.
 * Верните минимальную длину подмассива, сумма которого больше либо равна target.
 * Если такого подмассива не существует — верните 0.
 *
 * Краткое описание решения:
 * Используется sliding window -
 * Сдвигаем правый указатель, пока сумма меньше target
 * иначе
 * начинаем двигать левый указатель, пока сумма больше либо пока левый указатель не сравняется с правым
 *
 * Сложность:
 * По времени - O(n) (т.к. в худшем случае будет пройдено O(2*n)элементов, т.е O(n) )
 * По памяти - O(n)
 */
public class MinimumSizeSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var left = 0;
        var sum = 0;
        var minLength = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target && left <= right)
            {
                minLength = minLength == 0 ? right - left + 1 : Math.Min(minLength, right - left + 1);

                if (minLength == 1)
                {
                    return 1;
                }

                sum -= nums[left];
                left++;
            }
        }

        return minLength;
    }
}