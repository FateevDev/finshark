using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(WordSearch))]
public class WordSearchTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Exist_WhenCalled_ReturnsExpectedResults(char[][] board, string word, bool expected)
    {
        var sut = new WordSearch();

        var result = sut.Exist(board, word);

        Assert.Equal(expected, result);
    }

    public static TheoryData<char[][], string, bool> TestData()
    {
        return new TheoryData<char[][], string, bool>
        {
            {
                [
                    ['A', 'B', 'C', 'E'],
                    ['S', 'F', 'C', 'S'],
                    ['A', 'D', 'E', 'E'],
                ],
                "ABCCED",
                true
            },
            {
                [
                    ['A', 'B', 'C', 'E'],
                    ['S', 'F', 'C', 'S'],
                    ['A', 'D', 'E', 'E'],
                ],
                "SEE",
                true
            },
            {
                [
                    ['A', 'B', 'C', 'E'],
                    ['S', 'F', 'C', 'S'],
                    ['A', 'D', 'E', 'E'],
                ],
                "ABCB",
                false
            },
        };
    }
}