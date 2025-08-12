using System.Text;

namespace LeetCode.Tasks;

/*
 * Encode and Decode Strings https://leetcode.com/problems/encode-and-decode-strings/
 * https://neetcode.io/problems/string-encode-and-decode
 *
 * Design an algorithm to encode a list of strings to a single string.
 * The encoded string is then decoded back to the original list of strings.
 * Please implement encode and decode
 *
 * Спроектировать алгоритм кодирования списка строк в единую строку
 * Закодированная строка должна быть декодирована в оригинальный список строк
 *
 * Реализовать методы кодирования и декодирования
 *
 */
public class EncodeAndDecodeStrings
{
    public string Encode(IList<string> strs)
    {
        var result = new StringBuilder();

        foreach (var str in strs)
        {
            result.Append($"{str.Length}:{str}");
        }

        return result.ToString();
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        var delimiter = ':';
        var charsCountAsString = "";
        var charsCount = -1;
        var isCharsCountFound = false;
        var currentWord = "";

        for (var right = 0; right < s.Length; right++)
        {
            var currentChar = s[right];

            if (charsCount > 0)
            {
                currentWord += currentChar;
                charsCount--;

                if (charsCount == 0)
                {
                    result.Add(currentWord);
                    currentWord = "";
                    isCharsCountFound = false;
                    charsCountAsString = "";
                    continue;
                }
            }

            if (isCharsCountFound == false)
            {
                if (currentChar == delimiter)
                {
                    isCharsCountFound = true;
                    int.TryParse(charsCountAsString, out charsCount);

                    if (charsCount == 0)
                    {
                        return new List<string> { "" };
                    }

                    continue;
                }

                charsCountAsString += currentChar;
            }
        }

        return result;
    }
}