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
        if (s.Length == 1)
        {
            return false;
        }

        var dictionary = new Dictionary<char, char>()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' },
        };

        var left = 0;
        var isCenter = false;
        var isValid = false;
        var symbolSeen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            var currentChar = s[right];

            if (symbolSeen == 0 && isCenter == true)
            {
                isCenter = false;
                symbolSeen = 0;
            }

            if (isCenter == false && dictionary.ContainsKey(currentChar))
            {
                left = right - 1;
                isCenter = true;
            }

            if (isCenter)
            {
                if (symbolSeen == 0)
                {
                    return false;
                }

                isValid = dictionary[currentChar] == s[left];

                if (isValid == false)
                {
                    return false;
                }

                left--;
                symbolSeen--;
            }

            if (isCenter == false)
            {
                symbolSeen++;
            }
        }

        return isValid;
    }
}