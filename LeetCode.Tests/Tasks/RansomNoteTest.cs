using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(RansomNote))]
public class RansomNoteTest
{

    [Theory]
    [InlineData("bool", "bol", false)]
    [InlineData("bool", "mmm", false)]
    [InlineData("ol", "momomomolo", true)]
    [InlineData("momomomo", "momo", false)]
    public void CanConstruct_WhenCalled_ReturnsTrue(string ransomNote, string magazine, bool expected)
    {
        var sut = new RansomNote();

        var canConstruct = sut.CanConstruct(ransomNote, magazine);
        
        Assert.Equal(expected, canConstruct);
    }
}