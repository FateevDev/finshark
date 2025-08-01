namespace LeetCode.Tasks;

/*
 * Group Anagrams https://leetcode.com/problems/group-anagrams/description/
 *
 * Given an array of strings strs, group the anagrams together. You can return the answer in any order.
 *
 * Дан массив строк, нужно сгруппировать анаграммы вместе.
 * Вернуть результат в любом порядке.
 *
 * Сложность:
 * По времени O(n × m)
 * По памяти O(n × m) - т.к. считается хранение символа, а не строки (кол-во строк * кол-во символов)
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
        var counts = new int[26];

        foreach (var c in str)
        {
            counts[c - 'a']++;
        }

        return string.Join(":", counts);
    }
}