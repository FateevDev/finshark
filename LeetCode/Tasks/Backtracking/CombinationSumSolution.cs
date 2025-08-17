namespace LeetCode.Tasks.Backtracking;

/*
 * Combination Sum https://leetcode.com/problems/combination-sum
 *
 * Given an array of distinct integers candidates and a target integer target,
 * return a list of all unique combinations of candidates where the chosen numbers sum to target.
 * You may return the combinations in any order.
 * The same number may be chosen from candidates an unlimited number of times.
 * Two combinations are unique if the frequency of at least one of the chosen numbers is different.
 * The test cases are generated such that the number of unique combinations that sum up to target is
 * less than 150 combinations for the given input.
 *
 * Сумма комбинации
 * Дан массив отдельных целых чисел candidates и целевое число target.
 * Вернуть список всех уникальных комбинаций candidates где числа в сумме дают target.
 * Комбинации можно вернуть в любом порядке
 *
 * Одно и то же число может быть взято из candidates неограниченное число раз.
 * 2 комбинации уникальные, если частота хотя бы одного числа разная.
 *
 * Сложность:
 * По времени: O(n^(target/min_candidate))
 * По памяти: O(target/min_candidate + количество_решений × длина_решения)
 *
 * Временная сложность: O(n^(target/min_candidate))
 * candidates=[2,3], target=8
 * Анализ:
 * - Глубина дерева = target/min_candidate = 8/2 = 4 уровня
 * - Ветвление на каждом узле = n = 2 варианта (2 или 3)
 * - Максимальное количество узлов = 2⁴ = 16
 * 
 * Общая формула:
 * - Глубина = target/min_candidate
 * - Ветвление = n
 * - Узлов = n^(target/min_candidate)
 *  
 * Пространственная сложность: O(target/min_candidate + результаты)
 * 
 * Часть 1: Стек рекурсии + currentCombination**
 * O(target/min_candidate) - это максимальная глубина рекурсии
 * Пример: target=8, min_candidate=2
 * ``` 
 * Backtrack(target=8, combination=[])      // Уровень 0
 *   Backtrack(target=6, combination=[2])   // Уровень 1  
 *     Backtrack(target=4, combination=[2,2]) // Уровень 2
 *       Backtrack(target=2, combination=[2,2,2]) // Уровень 3
 *         Backtrack(target=0, combination=[2,2,2,2]) // Уровень 4
 * ```
 * Стек содержит 4 вызова одновременно** = O(4) = O(target/min_candidate)
 * Часть 2: Хранение результатов
 * O(количество_решений × длина_решения)
 * Для target=8, candidates=[2,3]:
 * - Решения: [2,2,2,2], [2,3,3], [3,2,3]
 * - 3 решения × средняя длина 3 = O(9)
 * 
 * Описание решения: используется техника Backtracking
 * Идея алгоритма:
 * 1. Рекурсивно пробуем каждое число из массива candidates
 * 2. Добавляем число в текущую комбинацию и вычитаем из target
 * 3. Продолжаем поиск с тем же числом или следующими числами
 * 4. После выхода из рекурсии убираем последний элемент из текущей комбинации (чтобы освободить место для других кандидатов)
 * 5. Если target = 0 - нашли валидную комбинацию
 * 6. Если target < 0 - откатываемся (backtrack)
 *
 * Как выглядит алгоритм для candidates=[2,3], target=8:
   
 *                                 target=8, idx=0, []
 *                               /                    \
 *                          взять 2                    взять 3
 *                     target=6, idx=0, [2]          target=5, idx=1, [3]
 *                    /                \                           \
 *               взять 2              взять 3                     взять 3
 *          target=4, idx=0, [2,2]    target=3, idx=1, [2,3]     target=2, idx=1, [3,3]
 *         /              \                 \                         \
 *     взять 2          взять 3           взять 3                     STOP
 *     target=2,        target=1,         target=0,                  (3 > 2)
 *     idx=0,           idx=1,            idx=1,
 *     [2,2,2]          [2,2,3]           [2,3,3] ✓
 *     /       \           |                |
 *  взять 2    взять 3    STOP          НАЙДЕНО!
 *  target=0,  target<0   (3>1)       results.Add([2,3,3])
 *  idx=0,    
 *  [2,2,2,2] ✓
 *     |
 *  НАЙДЕНО!
 *  results.Add([2,2,2,2])
 *   
 *
 */
public class CombinationSumSolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var results = new List<IList<int>>();
        var currentIndex = 0;

        Array.Sort(candidates);

        Backtrack(candidates, target, currentIndex, new List<int>(), results);

        return results;
    }

    private static void Backtrack(
        int[] candidates,
        int target,
        int currentIndex,
        List<int> currentCombination,
        IList<IList<int>> results)
    {
        if (target == 0)
        {
            results.Add(new List<int>(currentCombination));
            return;
        }

        if (target < 0)
        {
            return;
        }

        for (var i = currentIndex; i < candidates.Length; i++)
        {
            var candidate = candidates[i];

            if (candidate > target)
            {
                break;
            }

            currentCombination.Add(candidate);

            Backtrack(candidates, target - candidate, i, currentCombination, results);

            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}