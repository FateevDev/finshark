namespace LeetCode.Tasks;

// Ransom Note
// https://leetcode.com/problems/ransom-note/description/
// 
// Given two strings ransomNote and magazine,
// return true if ransomNote can be constructed using the letters from magazine and false otherwise.
// Each letter in magazine can only be used once in ransomNote.
// 
// Даны две строки — ransomNote и magazine.
// Верните true, если ransomNote можно составить, используя буквы из magazine, и false в противном случае.
// Каждую букву из magazine можно использовать только один раз при составлении ransomNote.
public class RansomNote
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomNoteLength = ransomNote.Length;

        if (ransomNoteLength == 0)
        {
            return true;
        }

        var magazineLength = magazine.Length;

        if (magazineLength == 0 || magazineLength < ransomNoteLength)
        {
            return false;
        }

        var characterUsageMap = GenerateCharacterUsageMap(magazine);

        foreach (var character in ransomNote)
        {
            if (!characterUsageMap.TryGetValue(character, out var count) || count == 0)
            {
                return false;
            }

            characterUsageMap[character]--;
        }

        return true;
    }

    private static Dictionary<char, int> GenerateCharacterUsageMap(string magazine)
    {
        var dictionary = new Dictionary<char, int>();

        foreach (var character in magazine)
        {
            dictionary[character] = dictionary.GetValueOrDefault(character, 0) + 1;
        }

        return dictionary;
    }
}