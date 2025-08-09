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
        if (k >= s.Length - 1)
        {
            return s.Length;
        }

        var longest = 0;
        var left = 0;
        var charCount = new int [26];
        var maxFrequency = 0;

        for (int right = 0; right < s.Length; right++)
        {
            var windowLength = right - left + 1;
            var currentCharacter = s[right];
            charCount[currentCharacter - 'A']++;
            maxFrequency = Math.Max(maxFrequency, charCount[currentCharacter - 'A']);

            if (k < windowLength - maxFrequency)
            {
                charCount[s[left] - 'A']--;
                left++;
                
                continue;
            }

            longest = Math.Max(windowLength, longest);

            if (longest == s.Length)
            {
                return longest;
            }
        }

        return longest;
    }
}