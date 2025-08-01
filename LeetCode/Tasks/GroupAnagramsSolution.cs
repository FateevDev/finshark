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
            var group = groups.TryGetValue(hash, out var found) ? found : [];

            group.Add(str);
            groups[hash] = group;
        }

        return groups.Values.ToList<IList<string>>();
    }

    private string Hash(string str)
    {
        var dictionary = new Dictionary<char, int>();

        foreach (var c in str.Order())
        {
            dictionary[c] = dictionary.GetValueOrDefault(c, 0) + 1;
        }

        return string.Join("", dictionary.Select(kvp => kvp.Key.ToString() + kvp.Value));
    }
}