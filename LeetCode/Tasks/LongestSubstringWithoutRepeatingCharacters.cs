namespace LeetCode.Tasks;

// https://leetcode.com/problems/longest-substring-without-repeating-characters/
// нужно найти самую длинную подстроку без повторяющихся символов
// решается двумя указателями, левым и правым.
// двигаем правый указатель, пока не наткнемся на совпадение.
// тогда двигаем левый указатель, пока не уберем совпадение.
// сложность
// по времени O(n)
// по памяти O(n)
public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLength(string s)
    {
        var longest = 0;
        var seen = new HashSet<char>();
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            var rightChar = s[right];

            while (seen.Contains(rightChar))
            {
                var leftChar = s[left];
                seen.Remove(leftChar);
                left++;
            }

            seen.Add(rightChar);
            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}