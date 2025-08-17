namespace LeetCode.Tasks;

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
 */
public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        var currentRow = 0;
        var currentIndex = 0;
        var currentCharIndex = 0;
        var directions = new[] { "right", "down", "left", "up" };
        var directionIndex = 0;

        return Backtrack(board, word, currentRow, currentIndex, currentCharIndex, directionIndex);
    }

    private bool Backtrack(
        char[][] board,
        string word,
        int currentRow,
        int currentIndex,
        int currentCharIndex,
        int directionIndex
    )
    {
        if (currentCharIndex >= word.Length)
        {
            return true;
        }

        for (var row = currentRow; row < board.Length; row++)
        {
            var currentRowLenght = board[row].Length;

            for (var index = currentIndex; index < currentRowLenght; index++)
            {
                var currentBoardChar = board[row][index];
                var currentWordChar = word[currentCharIndex];

                if (currentBoardChar != currentWordChar)
                {
                    if (currentCharIndex == 0)
                    {
                        continue;
                    }

                    directionIndex++;
                }
                else
                {
                    currentCharIndex++;
                }

                int nextRow, nextIndex;

                if (directionIndex == 0)
                {
                    nextRow = row;
                    nextIndex = index + 1;
                }
                else if (directionIndex == 1)
                {
                    nextRow = row + 1;
                    nextIndex = index;
                }
                else if (directionIndex == 2)
                {
                    nextRow = row;
                    nextIndex = index - 1;
                }
                else if (directionIndex == 3)
                {
                    nextRow = row - 1;
                    nextIndex = index;
                }
                else
                {
                    break;
                }

                if (nextRow > board.Length || nextRow < 0)
                {
                    continue;
                }

                if (nextIndex > currentRowLenght || nextIndex < 0)
                {
                    continue;
                }

                Backtrack(board, word, nextRow, nextIndex, currentCharIndex, directionIndex);
            }
        }

        return false;
    }
}