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
        var left = 0;
        var right = 0;

        while (right < s.Length)
        {
            var windowLenght = right - left + 1;
            var currentCharacter = s[right];
        }

        return longest;
    }

    private int maxCountCharacter(char currentCharacter)
    {
        var array = new int [26];

        array[currentCharacter - 'A']++;

    }
}