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
        var isCharsCountFound = false;
        var currentStringLenght = 0;
        var index = 0;

        while (index < s.Length)
        {
            var currentChar = s[index];

            if (isCharsCountFound == false)
            {
                if (char.IsDigit(currentChar))
                {
                    currentStringLenght = currentStringLenght * 10 + (currentChar - '0');
                }
                else if (currentChar == delimiter)
                {
                    isCharsCountFound = true;

                    if (currentStringLenght == 0)
                    {
                        return new List<string> { "" };
                    }
                }
            }

            index++;

            if (isCharsCountFound)
            {
                result.Add(s.Substring(index, currentStringLenght));

                isCharsCountFound = false;
                index += currentStringLenght;
                currentStringLenght = 0;
            }
        }

        return result;
    }
}