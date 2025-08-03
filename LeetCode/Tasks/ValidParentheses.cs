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
 *
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

        var seen = new List<char>();

        foreach (var currentCharacter in s)
        {
            if (dictionary.ContainsKey(currentCharacter))
            {
                seen.Add(currentCharacter);
                continue;
            }

            var last = seen.LastOrDefault(defaultValue: 'a');
            var lastCharacter = dictionary.GetValueOrDefault(last, 'b');

            if (lastCharacter == currentCharacter)
            {
                seen.RemoveAt(seen.Count - 1);
            }
            else
            {
                return false;
            }
        }

        return seen.Count == 0;
    }
}