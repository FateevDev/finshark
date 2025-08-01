namespace LeetCode.Tasks;

/*
 * Group Anagrams https://leetcode.com/problems/group-anagrams/description/
 *
 * Given an array of strings strs, group the anagrams together. You can return the answer in any order.
 *
 * Дан массив строк, нужно сгруппировать анаграммы вместе.
 * Вернуть результат в любом порядке.
 *
 *
 */
public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var hash = Hash(str);

            if (!groups.ContainsKey(hash))
            {
                groups[hash] = [];
            }

            groups[hash].Add(str);
        }

        return groups.Values.ToList<IList<string>>();
    }

    private string Hash(string str)
    {
        return new string(str.Order().ToArray());
    }
}