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

public static class ListTest
{
    public static void ListCrud()
    {
        // no types check
        // ArrayList list1 = new ArrayList();

        //Create
        List<int> list = [1, 2, 3, 4];

        //Update
        list.Add(1);
        list.Insert(0, 55);

        //Delete
        var newList = list.Where(number => number > 2).ToList();
        list.RemoveAt(0);

        //Read
        list.ForEach(number => Console.WriteLine(number));
        Console.WriteLine("\n");
        newList.ForEach(number => Console.WriteLine(number));
    }
    
    public static void ArrayCrud()
    {
        // Create
        string[] rats = ["fancy", "brown", "yellow"];

        // Read
        // foreach (var rat in rats)
        // {
        //     Console.WriteLine(rat);
        // }

        // Update
        // rats[0] = "bancy";

        // LINQ
        var enumerable = rats.Where((string rat) => rat.StartsWith("f"));

        enumerable.ToList().ForEach(rat =>
        {
            Console.WriteLine(rat);
            Console.WriteLine(rat + "!");
        });
        // Array.ForEach(rats, rat => Console.WriteLine(rat));
        Array.ForEach(rats, rat => Console.WriteLine(rat));

        foreach (var rat in rats)
        {
            Console.WriteLine(rat);
        }
    }
}