namespace LeetCode.Tasks;

/*
 * Valid Palindrome https://leetcode.com/problems/valid-palindrome/description
 *
 * A phrase is a palindrome if,
 * after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters,
 * it reads the same forward and backward. Alphanumeric characters include letters and numbers.
 * Given a string s, return true if it is a palindrome, or false otherwise.
 *
 * Корректный палиндром
 * Фраза является палиндромом, если, после конвертации всех заглавных букв в прописные и убирания
 * всех не буквенных и числовых символов, она читается слева направо и справа налево одинаково.
 *
 * Дана строка s, вернуть true если это палиндром, или false если нет
 *
 * Краткое описание решения:
 * Задача делится на 2 подзадачи - нормализация строки и определение палиндрома.
 *
 * 1. Нормализовать можно через нативные методы, через regex, а можно сразу идти в палиндром и нормализовывать символы
 * Нормализация всей строки даст O(n) по памяти, т.к. будем сканировать всю строку
 * Нормализация символов - O(1)
 *
 * 2. Проверка на палиндром.
 * Можно через стэк или через 2 указателя.
 * Стэк даст O(n) по памяти, 2 указателя - O(1)
 * Через 2 указателя - ставим их по концам слова и сдвигаем к друг другу
 *
 * Итого лучший вариант - нормализация символов + 2 указателя
 *
 * Сложность:
 * По времени - O(n)
 * По памяти - O(1)
 */
public class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            var leftChar = s[left];
            var rightChar = s[right];

            if (!char.IsLetterOrDigit(leftChar))
            {
                left++;
                continue;
            }

            if (!char.IsLetterOrDigit(rightChar))
            {
                right--;
                continue;
            }

            if (char.ToLowerInvariant(leftChar) != char.ToLowerInvariant(rightChar))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}