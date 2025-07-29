namespace LeetCode.Tasks;

/*
 * Container with most water
 *
 * You are given an integer array height of length n.
 * There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
 * Find two lines that together with the x-axis form a container,
 * such that the container contains the most water.
 * Return the maximum amount of water a container can store.
 *
 * Notice that you may not slant the container.
 *
 * Емкость с водой
 * Дан массив целых чисел (высот) длиной n
 * Нарисованы n вертикальных линий таких, что 2 точки i-той линий это (i, 0) и (i, height[i]).
 * Найти 2 линии, которые образуют по оси x контейнер, который содержит большее кол-во воды
 * Вернуть максимальное кол-во воды, которое может содержать контейнер.
 *
 * Контейнер нельзя наклонять.
 *
 * Краткое описание решения:
 * Есть 2 указателя, они левый - в начале массива, правый - в конце.
 * Рассчитываем объем воды (таким образом мы пытаемся рассчитать максимальный объем)
 * 1. Смотрим, какой указатель стоит на низшей стенке и двигаем его,
 * если стенки равны - двигаем любой, например левый
 * 2. Рассчитываем новый объем воды, к шагу 1
 *
 * Сложность
 * по времени - O(n)
 * по памяти - O(1)
 */
public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        var maxArea = 0; 
        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var leftWall = height[left];
            var rightWall = height[right];
            var area = Math.Min(leftWall, rightWall) * (right - left);
            maxArea = Math.Max(maxArea, area);

            if (leftWall <= rightWall)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}