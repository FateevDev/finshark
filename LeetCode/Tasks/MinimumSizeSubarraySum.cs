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

            if (sum == target)
            {
                minLength = minLength == 0 ? right - left + 1 : Math.Min(minLength, right - left + 1);

                if (minLength == 1)
                {
                    return minLength;
                }

                left = right;
                sum = nums[right];

                continue;
            }

            if (sum <= target)
            {
                continue;
            }

            while (left <= right)
            {
                minLength = minLength == 0 ? right - left + 1 : Math.Min(minLength, right - left + 1);

                sum -= nums[left];
                left++;

                if (sum < target)
                {
                    break;
                }

                if (sum >= target)
                {
                    minLength = minLength == 0 ? right - left + 1 : Math.Min(minLength, right - left + 1);
                }

                if (minLength == 1)
                {
                    return 1;
                }
            }
        }

        return minLength;
    }
}