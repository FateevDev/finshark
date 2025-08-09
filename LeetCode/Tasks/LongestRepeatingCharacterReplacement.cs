namespace LeetCode.Tasks;

/*
 * Longest Repeating Character Replacement https://leetcode.com/problems/longest-repeating-character-replacement
 *
 * You are given a string s and an integer k.
 * You can choose any character of the string and change it to any other uppercase English character.
 * You can perform this operation at most k times.
 * Return the length of the longest substring containing the same letter you can get
 * after performing the above operations.
 *
 * Замена самого длинного повторяющегося символа
 *
 * Дана строка s и целое число k
 * Можно выбрать любой символ в строке и заменить его на любой
 * другой символ английского алфавита в верхнем регистре.
 * Эту операцию можно выполнить максимум k раз.
 * Вернуть длину самой длинной подстроки содержащей одну и туже букву после выполнения операции замены.
 *
 * Сложность:
 * По времени: O(n)
 * По памяти: О(1)
 * 
 * Описание решения:
 * Использование скользящего окна.
 * Пример A B D D, k = 1
 * 1. Изначально окно состоит из одного символа (A)
 * 2. Если окно валидно, то расширяем окно право (AB) до тех пор, пока оно станет невалидным (A B D).
 * 3. Тогда переносим левую границу окна на один символ (B D), к шагу 2
 *
 * Как считаем валидность окна:
 * Нужно понимать, сколько символов мы можем заменить в окне, чтобы все они стали одинаковыми.
 * Для этого нам не нужны конкретные значения символов, а нужна частотность символов.
 * Тогда число замен можно вычислить как:
 * (длина окна) - (максимальная частота символа) = (столько символов нужно заменить)
 * 
 * Например
 * окно ABD, k = 1
 * длина окна = 3. Сколько символов нужно заменить?
 * Длина окна - максимальная частотность = 3 - 1 = 2
 *
 * Как посчитать частотность символов?
 * Через массив, длиной = количество возможных символов (т.е. 26)
 * Каждый раз переходя к новому символу, добавляем его в массив и считаем, сколько таких добавлений мы сделали.
 * Максимальная частота тогда = максимум из частоты текущего символа и прошлого максимального значения частоты.
 */
public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        if (k >= s.Length - 1)
        {
            return s.Length;
        }

        var longest = 0;
        var left = 0;
        var charCount = new int [26];
        var maxFrequency = 0;

        for (int right = 0; right < s.Length; right++)
        {
            var windowLength = right - left + 1;
            var currentCharacter = s[right];
            charCount[currentCharacter - 'A']++;
            maxFrequency = Math.Max(maxFrequency, charCount[currentCharacter - 'A']);

            if (k < windowLength - maxFrequency)
            {
                charCount[s[left] - 'A']--;
                left++;
                
                continue;
            }

            longest = Math.Max(windowLength, longest);

            if (longest == s.Length)
            {
                return longest;
            }
        }

        return longest;
    }
}