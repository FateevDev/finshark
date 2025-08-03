namespace LeetCode.Tasks;

/*
 * Valid Parentheses https://leetcode.com/problems/valid-parentheses/description/?source=submission-noac
 *
 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
 * determine if the input string is valid.
 *
 * An input string is valid if:
 * 1. Open brackets must be closed by the same type of brackets.
 * 2. Open brackets must be closed in the correct order.
 * 3. Every close bracket has a corresponding open bracket of the same type.
 *
 * Корректные скобки
 *
 * Дана строка, содержащая только символы '(', ')', '{', '}', '[' и ']',
 * определить, является ли строка корректной
 *
 * Строка корректна, если:
 * 1. Открытые скобки закрыты такими же скобками
 * 2. Открытые скобки закрыты в правильном порядке
 * 3. Каждая закрытая скобка имеет соответсвующую открытую скобку такого же типа
 *
 * Описание решения:
 * Для решения задачи нужно использовать stack - LIFO (последний пришел - первый ушел)
 * Если скобка открывающая - добавляем ее в стэк
 * Если закрывающая - извлекаем из стэка последнюю открывающую скобку, находим для нее соответствующую закрывающую и
 * сравниваем закрывающие - если они совпадают, идем дальше, если нет - заканчиваем.
 *
 * На выходе проверяем, что в стэке не осталось элементов - тогда строка валидна.
 *
 * Сложность:
 * По скорости - O(n)
 * По памяти - O(n)
 */
public class ValidParentheses
{
    public bool IsValid(string s)
    {
        var dictionary = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
        };

        var seen = new Stack<char>();

        foreach (var currentCharacter in s)
        {
            if (dictionary.ContainsKey(currentCharacter))
            {
                seen.Push(currentCharacter);
                continue;
            }

            seen.TryPop(out var last);
            var lastCharacter = dictionary.GetValueOrDefault(last, 'b');

            if (lastCharacter != currentCharacter)
            {
                return false;
            }
        }

        return seen.Count == 0;
    }
}