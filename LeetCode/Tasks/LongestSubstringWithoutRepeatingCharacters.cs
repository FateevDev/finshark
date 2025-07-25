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

        HashSet<char> seen = new();

        foreach (var character in s)
        {
            if (seen.Contains(character))
            {
                longest = Math.Max(longest, seen.Count);
                seen.Clear();
            }

            seen.Add(character);
        }

        return Math.Max(longest, seen.Count);
    }
}