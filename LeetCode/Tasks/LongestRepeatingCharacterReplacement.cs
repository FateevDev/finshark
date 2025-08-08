namespace LeetCode.Tasks;

/*
 * Longest Repeating Character Replacement https://leetcode.com/problems/longest-repeating-character-replacement
 *
 * You are given a string s and an integer k.
 * You can choose any character of the string and change it to any other uppercase English character.
 * You can perform this operation at most k times.
 * Return the length of the longest substring containing the same letter you can get
 * after performing the above operations.
 *
 * Замена самого длинного повторяющегося символа
 *
 * Дана строка s и целое число k
 * Можно выбрать любой символ в строке и заменить его на любой
 * другой символ английского алфавита в верхнем регистре.
 * Эту операцию можно выполнить максимум k раз.
 * Вернуть длину самой длинной подстроки содержащей одну и туже букву после выполнения операции замены.
 *
 */
public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        var longest = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var currentLongest = 1;
            var currentChar = s[i];
            var pointer = i;
            var remainReplacements = k;

            while (remainReplacements >= 0)
            {
                longest = Math.Max(longest, currentLongest);

                if (longest == s.Length)
                {
                    return longest;
                }

                if (pointer == (s.Length - 1))
                {
                    pointer = i;
                    pointer--;
                }
                else if (pointer < i)
                {
                    pointer--;
                }
                else
                {
                    pointer++;
                }

                if (s[pointer] != currentChar)
                {
                    if (remainReplacements == 0)
                    {
                        break;
                    }

                    remainReplacements--;
                }

                currentLongest++;
            }
        }

        return longest;
    }
}