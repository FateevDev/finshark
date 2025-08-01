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
            var sortedLetters = SortedLetters(str);
            var group = groups.TryGetValue(sortedLetters, out var found) ? found : [];

            group.Add(str);
            groups[sortedLetters] = group;
        }

        return groups.Values.ToList<IList<string>>();
    }

    private string SortedLetters(string str)
    {
        var list = "";
        char min = '~';
        var chars = str.ToList();

        while (chars.Count > 0)
        {
            foreach (var c in chars)
            {
                min = min > c ? c : min;
            }

            list += min;
            chars.Remove(min);
            min = '~';
        }

        return list;
    }
}