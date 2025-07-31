namespace LeetCode.Tasks;

/*
 * Integer to Roman https://leetcode.com/problems/integer-to-roman/description/
 * Seven different symbols represent Roman numerals with the following values:
 *
 *  Symbol	Value
 *  I	1
 *  V	5
 *  X	10
 *  L	50
 *  C	100
 *  D	500
 *  M	1000
 *
 * Roman numerals are formed by appending the conversions of decimal place values from highest to lowest.
 * Converting a decimal place value into a Roman numeral has the following rules:
 *
 * If the value does not start with 4 or 9,
 * select the symbol of the maximal value that can be subtracted from the input,
 * append that symbol to the result, subtract its value, and convert the remainder to a Roman numeral.
 *
 * If the value starts with 4 or 9 use the subtractive form
 * representing one symbol subtracted from the following symbol,
 * for example, 4 is 1 (I) less than 5 (V): IV and 9 is 1 (I) less than 10 (X): IX.
 * Only the following subtractive forms are used: 4 (IV), 9 (IX), 40 (XL), 90 (XC), 400 (CD) and 900 (CM).
 *
 * Only powers of 10 (I, X, C, M) can be appended consecutively at most 3 times to represent multiples of 10.
 * You cannot append 5 (V), 50 (L), or 500 (D) multiple times.
 * If you need to append a symbol 4 times use the subtractive form.
 * Given an integer, convert it to a Roman numeral.
 *
 * Римские цифры.
 * Если значение не начинается с 4 или 9:
 * Выбрать символ наибольшего значения, добавить символ к результату.
 *
 * Если значение начинается с 4 или 9, использовать формы IV и IX (вычитание)
 * Используются только формы 4 (IV), 9 (IX), 40 (XL), 90 (XC), 400 (CD) и 900 (CM).
 *
 * Только степени 10 (I, X, C, M) могут быть добавлены максимально 3 раза чтобы воспроизвести степени 10
 * Нельзя добавлять 5 (V), 50 (L), или 500 (D) несколько раз.
 * Если нужно добавить символ 4 раза, использовать формы вычитания
 *
 * Краткое описание решения:
 * Каждый порядок обрабатывается как остальные, просто меняется словарь:
 * 1. Находим словарь
 * 2. Находим текущее значение
 * 3. В зависимости от значения формируем строку -
 * 4. Если число меньше 4 или больше 4 и меньше 9 - находим базовую строку
 * 4.1 для чисел меньше 4 - это пустая строка
 * 4.2. для остальных - это символ из словаря под индексом 1
 * 5. Если это число 4 - символы из словаря с индексами 1 + 0
 * 6. Если это число 9 - символы из словаря с индексами 2 + 0
 *
 * Сложность:
 * По времени - O(n)
 * По памяти - O(1)
 */
public class IntegerToRoman
{
    public string IntToRoman(int num)
    {
        var result = "";

        var dictionary = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        foreach (var (key, value) in dictionary)
        {
            var count = num / key;

            for (var i = 0; i < count; i++)
            {
                result += value;
            }

            num -= count * key;
        }

        return result;
    }

    public string IntToRoman2(int num)
    {
        var result = "";
    
        var dictionary = new[]
        {
            new[] { "I", "V", "X" },
            new[] { "X", "L", "C" },
            new[] { "C", "D", "M" },
            new[] { "M" },
        };
        var asString = num.ToString();
    
        for (var i = 1; i <= asString.Length; i++)
        {
            var currentDictionary = dictionary[asString.Length - i];
            var currentValue = int.Parse(asString[i - 1].ToString());
    
            switch (currentValue)
            {
                case < 4 or (> 4 and < 9):
                {
                    var baseChar = currentValue < 4 ? "" : currentDictionary[1];
                    for (var j = 0; j < (currentValue % 5); j++)
                    {
                        baseChar += currentDictionary[0];
                    }
    
                    result += baseChar;
                    break;
                }
                case 4:
                    result += currentDictionary[0] + currentDictionary[1];
                    break;
                case 9:
                    result += currentDictionary[0] + currentDictionary[2];
                    break;
            }
        }
    
        return result;
    }
}