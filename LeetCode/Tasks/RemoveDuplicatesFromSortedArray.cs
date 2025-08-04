namespace LeetCode.Tasks;

/*
 * Remove Duplicates from Sorted Array https://leetcode.com/problems/remove-duplicates-from-sorted-array/description
 *
 * Given an integer array nums sorted in non-decreasing order,
 * remove the duplicates in-place such that each unique element appears only once.
 * The relative order of the elements should be kept the same.
 * Then return the number of unique elements in nums.
 *
 * Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:
 * Change the array nums such that the first k elements of nums contain the unique elements
 * in the order they were present in nums initially.
 * The remaining elements of nums are not important as well as the size of nums.
 * Return k.
 *
 * Убрать дубликаты из отсортированного массива.
 * Дан массив целых чисел отсортированный по возрастанию.
 * Убрать дубликаты чисел так, чтобы каждый уникальный элемент встречался только один раз.
 * Относительный порядок элементов должен сохранится.
 * Вернуть кол-во уникальных элементов.
 *
 * Рассматривая кол-во уникальных элементов как k, чтобы был принят, нужно:
 * Изменить длину массива так, чтобы первые k элементов содержали уникальные элементы
 * в изначальном порядке
 * Остальные элементы неважны.
 * Вернуть k
 *
 * Краткое описание решения:
 * Есть 2 указателя, левый и правый.
 * Левый устанавливается на первый элемент массива, а правый двигается до конца массива.
 * Как только правым указателем находим элемент, который не совпадает с элементом левого указателя,
 * Ставим правый элемент на следующую позицию от левого и сдвигаем левый.
 * Результат возвращаем как кол-во сдвигов левого указателя + 1
 * (если он вообще не сдвигался, то значит есть только один уникальный элемент)
 *
 * Сложность:
 * По времени: O(n)
 * По памяти: O(1)
 */
public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums)
    {
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            var leftNumber = nums[left];
            var rightNumber = nums[right];

            if (leftNumber != rightNumber)
            {
                nums[++left] = rightNumber;
            }
        }

        return left + 1;
    }

    /*
     * OnePointer
     * Есть окно из 2 элементов и указатель.
     * Указатель стоит на втором элементе.
     * Сравниваем числа в окне - если они не равны, то ставим число на указатель и двигаем указатель.
     * Цикл начинается со второго элемента! Окно смотрит на текущий и предыдущий элемент.
     */
    public int RemoveDuplicates2(int[] nums)
    {
        var pointer = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[pointer++] = nums[i];
            }
        }

        return pointer;
    }
}