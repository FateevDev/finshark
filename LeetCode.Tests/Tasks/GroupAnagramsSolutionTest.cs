using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(GroupAnagramsSolution))]
public class GroupAnagramsSolutionTest
{
    [Theory]
    [InlineData(
        new[] { "eat", "tea", "tan", "ate", "nat", "bat" },
        new[] { "eat", "tea", "ate", "tan", "nat", "bat" },
        3
    )]
    [InlineData(new[] { "" }, new[] { "" }, 1)]
    [InlineData(new[] { "a" }, new[] { "a" }, 1)]
    [InlineData(new[] { "bdddddddddd", "bbbbbbbbbbc" }, new[] { "bdddddddddd", "bbbbbbbbbbc" }, 2)]
    public void GroupAnagrams_WhenCalled_ReturnsExpectedResult(string[] strs, string[] expected, int count)
    {
        var sut = new GroupAnagramsSolution();

        var groupAnagrams = sut.GroupAnagrams(strs);

        Assert.Equal(count, groupAnagrams.Count);
        Assert.Equal(expected, groupAnagrams.SelectMany(x => x));
    }
}