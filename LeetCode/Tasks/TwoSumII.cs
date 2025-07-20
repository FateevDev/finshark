namespace LeetCode.Tasks;

// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/

// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order,
// find two numbers such that they add up to a specific target number.
// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
// Return the indices of the two numbers, index1 and index2,
// added by one as an integer array [index1, index2] of length 2.
// The tests are generated such that there is exactly one solution. You may not use the same element twice.
// Your solution must use only constant extra space.

// Дан массив интов сортированных в возрастающем порядке
// Найти 2 числа таких, которые при сложении будут равны целевому числу
// Эти числа должны быть указаны как numbers[index1] и numbers[index2]
// При этом 1 <= index1 < index2 < numbers.length
// Вернуть индексы 2х чисел, как массив [index1, index2]
// Тесты гарантируют, что существует ровно одно решение. (не бывает, что решения нет или их несколько)  
// Нельзя использовать один и тот же элемент дважды.
// Ваше решение должно использовать только константную дополнительную память.

// Краткое обьяснение решения
// подход со словарем нужно использовать, когда массив несортирован - 
// т.е. нам нужно обойти его весь
// Раз массив сортирован, нужно поставить указатели слева и справа и постепенно сдвигать их
// - если число больше требуемого, сдвигаем правый (т.е. уменьшаем сумму)
// - если число меньше - сдвигаем левый, т.е. увеличиваем
public class TwoSumII
{
    public int[] TwoSum(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (right > left)
        {
            var sum = nums[left] + nums[right];

            if (sum == target)
            {
                return new[] { left + 1, right + 1 };
            }

            if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        throw new Exception("numbers not found");
    }

    // public int[] TwoSum(int[] nums, int target)
    // {
    //     Dictionary<int, int> dict = new();
    //
    //     for (int pointer = 0; pointer < nums.Length; pointer++)
    //     {
    //         var num = nums[pointer];
    //         var expectedNumber = target - num;
    //
    //         if (dict.ContainsKey(expectedNumber))
    //         {
    //             return new[] { dict[expectedNumber] + 1, pointer + 1, };
    //         }
    //
    //         dict.TryAdd(num, pointer);
    //     }
    //
    //     throw new Exception("numbers not found");
    // }

    // public int[] TwoSum(int[] nums, int target)
    // {
    //     for (int pointer1 = 0; pointer1 < nums.Length; pointer1++)
    //     {
    //         for (int pointer2 = pointer1 + 1; pointer2 < nums.Length; pointer2++)
    //         {
    //             if (nums[pointer1] + nums[pointer2] == target)
    //             {
    //                 return new[] { pointer1 + 1, pointer2 + 1 };
    //             }
    //         }
    //     }
    //
    //     throw new Exception("numbers not found");
    // }

    // public int[] TwoSum(int[] nums, int target)
    // {
    //     var pointer1 = 0;
    //     var pointer2 = 1;
    //     
    //     while (pointer1 < nums.Length - 1)
    //     {
    //         if (pointer2 > nums.Length - 1)
    //         {
    //             pointer1++;
    //             pointer2 = pointer1 + 1;
    //         }
    //     
    //         var firstNumber = nums[pointer1];
    //         var expectedNumber = target - firstNumber;
    //         var secondNumber = nums[pointer2];
    //     
    //         if (secondNumber == expectedNumber)
    //         {
    //             return new[] { pointer1 + 1, pointer2 + 1 };
    //         }
    //     
    //         pointer2++;
    //     }
    //     
    //     throw new Exception("numbers not found");
    // }
}