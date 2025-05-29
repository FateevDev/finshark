namespace Sandbox;

public class Solution
{
    // public int[] TwoSum(int[] nums, int target)
    // {
    //     for (int i = 0; i < nums.Length; i++)
    //     {
    //         for (int j = i + 1; j < nums.Length; j++)
    //         {
    //             if (nums[i] + nums[j] == target)
    //             {
    //                 return new[] { i, j };
    //             }
    //         }
    //     }
    //
    //     throw new ArgumentException("No solution");
    // }

    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return new[] { dict[complement], i };
            }

            dict.Add(nums[i], i);
        }

        throw new ArgumentException("No solution");
    }

    public static bool CheckDuplicates(int[] nums)
    {
        HashSet<int> set = new();

        for (int i = 0; i < nums.Length; i++)
        {
            var item = nums[i];

            if (set.Contains(item))
            {
                return true;
            }

            set.Add(item);
        }

        return false;
    }
}