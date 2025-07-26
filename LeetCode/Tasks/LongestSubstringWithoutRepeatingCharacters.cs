namespace LeetCode.Tasks;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLength(string s)
    {
        var longest = 0;

        if (s.Length == 0)
        {
            return longest;
        }

        if (s.Length == 1)
        {
            return 1;
        }

        var seen = new HashSet<char>();

        int left = 0;
        int right = 0;
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