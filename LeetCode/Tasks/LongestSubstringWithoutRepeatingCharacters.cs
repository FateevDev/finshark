namespace LeetCode.Tasks;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLength(string s)
    {
        var longest = 0;
        var seen = new HashSet<char>();
        var left = 0;
        var right = 0;
        var rightChar = s[right];

        while (right < s.Length - 1)
        {
            seen.Add(rightChar);

            right++;
            rightChar = s[right];

            if (seen.Add(rightChar))
            {
                continue;
            }

            longest = Math.Max(longest, seen.Count);

            while (seen.Contains(rightChar))
            {
                var leftChar = s[left];
                seen.Remove(leftChar);
                left++;
            }
        }

        return Math.Max(longest, seen.Count);
    }
}