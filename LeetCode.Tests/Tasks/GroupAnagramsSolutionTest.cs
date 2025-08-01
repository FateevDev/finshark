using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(GroupAnagramsSolution))]
public class GroupAnagramsSolutionTest
{
    [Theory]
    [InlineData(
        new[] { "eat", "tea", "tan", "ate", "nat", "bat" },
        new[] { "eat", "tea", "ate", "tan", "nat", "bat" }),
    ]
    [InlineData(new[] { "" }, new[] { "" })]
    [InlineData(new[] { "a" }, new[] { "a" })]
    public void GroupAnagrams_WhenCalled_ReturnsExpectedResult(string[] strs, string[] expected)
    {
        var sut = new GroupAnagramsSolution();

        var groupAnagrams = sut.GroupAnagrams(strs);

        Assert.Equal(expected, groupAnagrams.SelectMany(x => x));
    }
}