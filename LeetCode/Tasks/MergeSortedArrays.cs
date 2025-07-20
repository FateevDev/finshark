namespace LeetCode.Tasks;

// Merge Sorted Array
// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order,
// and two integers m and n, representing the number of elements in nums1 and nums2.
// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
// The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
// To accommodate this, nums1 has a length of m + n,
// where the first m elements denote the elements that should be merged,
// and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

// Объединить отсортированные массивы
// Даны два целочисленных массива nums1 и nums2, отсортированные по возрастанию, и два числа m и n,
// которые обозначают количество элементов в nums1 и nums2 соответственно.
// Необходимо объединить nums1 и nums2 в один массив, отсортированный по возрастанию.
// Итоговый отсортированный массив не должен возвращаться из функции,
// а должен быть записан прямо в массив nums1.
// Для этого nums1 имеет длину m + n, где первые m элементов — это данные, которые нужно объединить,
// а последние n элементов равны 0 и должны быть проигнорированы. nums2 имеет длину n.
public class MergeSortedArrays
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var pointer1 = m - 1;
        var pointer2 = n - 1;
        var pointer3 = m + n - 1;

        while (pointer2 >= 0)
        {
            if (pointer1 >= 0 && nums1[pointer1] > nums2[pointer2])
            {
                nums1[pointer3] = nums1[pointer1];
                pointer1--;
            }
            else
            {
                nums1[pointer3] = nums2[pointer2];

                pointer2--;
            }

            pointer3--;
        }
    }
}