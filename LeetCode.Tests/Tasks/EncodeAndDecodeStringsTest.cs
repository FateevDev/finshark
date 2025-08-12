using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(EncodeAndDecodeStrings))]
public class EncodeAndDecodeStringsTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Decode_WhenCalled_ReturnsExpectedResult(IList<string> strs)
    {
        var sut = new EncodeAndDecodeStrings();

        var encodedStrings = sut.Encode(strs);
        var decodedStrings = sut.Decode(encodedStrings);

        Assert.Equal(strs, decodedStrings);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            new List<string> { "neet", "code", "love", "you" },
        ];

        yield return
        [
            new List<string> { "we", "say", ":", "yes" },
        ];

        yield return
        [
            new List<string> { "5:abc", "de2:fg" },
        ];
    }
}