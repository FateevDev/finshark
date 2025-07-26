namespace LeetCode.Tasks;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLength(string s)
    {
        var longest = 0;
        var seen = new HashSet<char>();
        var left = 0;

        foreach (var rightChar in s)
        {
            while (seen.Contains(rightChar))
            {
                var leftChar = s[left];
                seen.Remove(leftChar);
                left++;
            }

            seen.Add(rightChar);
            longest = Math.Max(longest, seen.Count);
        }

        return longest;
    }
}