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
        if (wordIndex == word.Length - 1)
        {
            return true;
        }

        var offsets = new[] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, -1 } };

        foreach (var offset in offsets)
        {
            var nextRow = currentRow + offset[0];
            var nextIndex = currentIndex + offset[1];

            if (
                nextRow >= board.Length
                || nextRow < 0
                || nextIndex >= board[currentRow].Length
                || nextIndex < 0
            )
            {
                continue;
            }

            var currentBoardChar = board[nextRow][nextIndex];
            var currentWordIndex = wordIndex + 1;
            var currentWordChar = word[currentWordIndex];

            if (currentBoardChar == currentWordChar)
            {
                if (Backtrack(board, word, nextRow, nextIndex, currentWordIndex))
                {
                    return true;
                }
            }
        }

        return false;
    }
}