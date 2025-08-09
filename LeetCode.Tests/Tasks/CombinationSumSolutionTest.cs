using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(CombinationSumSolution))]
public class CombinationSumSolutionTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void CombinationSumSolution_WhenCalled_ReturnExpectedResult(
        int[] candidates,
        int target,
        IList<IList<int>> expected
    )
    {
        var sut = new CombinationSumSolution();

        var combinationSum = sut.CombinationSum(candidates, target);

        Assert.Equal(expected, combinationSum);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            new[] { 2, 3, 6, 7 },
            7,
            new List<IList<int>> { new[] { 2, 2, 3 }, new[] { 7 } }
        ];

        yield return
        [
            new[] { 2, 3, 5 },
            7,
            new List<IList<int>> { new[] { 2, 2, 2, 2 }, new[] { 2, 3, 3 }, new[] { 3, 5 } },
        ];

        yield return
        [
            new[] { 2 },
            1,
            new List<IList<int>>(),
        ];
    }
}