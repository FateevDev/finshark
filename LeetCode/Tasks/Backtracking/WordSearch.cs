namespace LeetCode.Tasks.Backtracking;

/*
 * Word Search https://leetcode.com/problems/word-search/description/
 *
 * Given an m x n grid of characters board and a string word, return true if word exists in the grid.
 * The word can be constructed from letters of sequentially adjacent cells,
 * where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
 *
 * Даны m*n таблица символов board и строка word, вернуть true если word существует в таблице
 * Слово может быть создано из букв соседних ячеек, где соседние ячейки находятся рядом
 * друг с другом горизонтально или вертикально
 * Одна и та же ячейка с буквой не может быть использована более одного раза
 *
 * Сложность алгоритма:
 * По времени - O(m * n * 4 ^ L) - т.е. произведение колонок на число строк и еще длина слова в степени 4,
 * т.к. всего 4 варианта ветвления
 * По памяти - O(L) - т.к. рекурсия может быть максимально глубиной в длину слова
 *
 * Описание решения:
 * Используется модифицированный Backtracking
 *
 * 1. Итеративно проходим каждую букву таблицы.
 * 2. Если она равна букве начала искомого слова, то проваливаемся в рекурсию:
 * 2.1 Сначала обозначаем условие выхода из рекурсии - если текущий индекс буквы слова равен длине слова, значит,
 * слово составлено из букв в таблице.
 * 2.2 Заменяем текущую букву из таблицы на любой символ - чтобы алгоритм не вернулся к ней еще раз
 * 2.3 Перебираем все 4 возможных направления поиска - вправо, вниз, влево, вверх
 * 2.4 Сразу смотрим нарушение границ - не должны выйти за пределы таблицы
 * 2.5 Если следующая буква таблицы равна следующей букве слова, то опять запускаем рекурсию
 * 2.6 Если рекурсия вернула true, то возвращаем true - слово найдено
 * 2.7 После выхода из рекурсии возвращаем замененную букву из таблица на место - чтобы привести исходный массив
 * в прежний вид.
 */
public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[row].Length; col++)
            {
                var currentBoardChar = board[row][col];
                var currentWordChar = word[0];

                if (currentBoardChar == currentWordChar)
                {
                    if (Backtrack(board, word, row, col, 0))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool Backtrack(
        char[][] board,
        string word,
        int currentRow,
        int currentIndex,
        int wordIndex
    )
    {
        if (wordIndex == word.Length)
        {
            return true;
        }

        if (
            currentRow >= board.Length
            || currentRow < 0
            || currentIndex >= board[currentRow].Length
            || currentIndex < 0
            || board[currentRow][currentIndex] != word[wordIndex]
        )
        {
            return false;
        }

        var currentBoardChar = board[currentRow][currentIndex];
        board[currentRow][currentIndex] = '#';

        var result =
            Backtrack(board, word, currentRow, currentIndex + 1, wordIndex + 1)
            || Backtrack(board, word, currentRow, currentIndex - 1, wordIndex + 1)
            || Backtrack(board, word, currentRow + 1, currentIndex, wordIndex + 1)
            || Backtrack(board, word, currentRow - 1, currentIndex, wordIndex + 1);

        board[currentRow][currentIndex] = currentBoardChar;

        return result;
    }
}