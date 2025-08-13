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
 * Описание решения:
 * В задаче не получится использовать json, т.к. он не может обработать все символы.
 * Например, в json используются как служебные ", {, }, [, ] и т.п.
 *
 * Для реализации кодирования: добавляем в начало каждой строки кол-во символов в ней + разделитель,
 * чтобы не было неоднозначностей для строк типа 333
 *
 * Для реализации декодирования:
 * Циклом проходим по кодированной строке. Если символ - цифра, то собираем все цифры в единое число
 * до тех пор, пока не встретим разделитель.
 *
 * Как только встретили разделитель -
 * добавляем в результат подстроку с текущего индекса по кол-во символов.
 * Сбрасываем текущее кол-во.
 *
 * Сложность:
 * Кодирования
 * По времени: O(n)
 * По памяти: O(n)
 *
 * Декодирования
 * По времени: O(n)
 * По памяти: O(n)
 */
public class EncodeAndDecodeStrings
{
    public string Encode(IList<string> strs)
    {
        var result = new StringBuilder();

        foreach (var str in strs)
        {
            result.Append(str.Length).Append(':').Append(str);
        }

        return result.ToString();
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        var currentStringLenght = 0;
        var index = 0;

        while (index < s.Length)
        {
            var currentChar = s[index];

            if (char.IsDigit(currentChar))
            {
                currentStringLenght = currentStringLenght * 10 + (currentChar - '0');
                index++;
            }
            else if (currentChar == ':')
            {
                index++;
                result.Add(s.AsSpan(index, currentStringLenght).ToString());

                index += currentStringLenght;
                currentStringLenght = 0;
            }
            else
            {
                return result;
            }
        }

        return result;
    }
}