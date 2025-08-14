using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(LowestCommonAncestorOfABinarySearchTree))]
public class LowestCommonAncestorOfABinarySearchTreeTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void LowestCommonAncestor_WhenCalled_ReturnsExpectedResult(
        TreeNode root,
        TreeNode p,
        TreeNode q,
        TreeNode expected
    )
    {
        var sut = new LowestCommonAncestorOfABinarySearchTree();

        var lowestCommonAncestor = sut.LowestCommonAncestorIterative(root, p, q);

        Assert.Equal(expected.val, lowestCommonAncestor?.val);
    }

    public static TheoryData<TreeNode, TreeNode, TreeNode, TreeNode> TestData()
    {
        return new TheoryData<TreeNode, TreeNode, TreeNode, TreeNode>
        {
            {
                new TreeNode(6,
                    new TreeNode(2, new TreeNode(0), new TreeNode(4, new TreeNode(3), new TreeNode(5))),
                    new TreeNode(8, new TreeNode(7), new TreeNode(8))
                ),
                new TreeNode(2),
                new TreeNode(8),
                new TreeNode(6)
            },
            {
                new TreeNode(6,
                    new TreeNode(2, new TreeNode(0), new TreeNode(4, new TreeNode(3), new TreeNode(5))),
                    new TreeNode(8, new TreeNode(7), new TreeNode(8))
                ),
                new TreeNode(2),
                new TreeNode(4),
                new TreeNode(2)
            },
            {
                new TreeNode(6,
                    new TreeNode(2, new TreeNode(0), new TreeNode(4, new TreeNode(3), new TreeNode(5))),
                    new TreeNode(8, new TreeNode(7), new TreeNode(8))
                ),
                new TreeNode(3),
                new TreeNode(5),
                new TreeNode(4)
            },
            {
                new TreeNode(2, new TreeNode(1)),
                new TreeNode(2),
                new TreeNode(1),
                new TreeNode(2)
            },
            {
                new TreeNode(3, new TreeNode(1, right: new TreeNode(2)), new TreeNode(4)),
                new TreeNode(2),
                new TreeNode(3),
                new TreeNode(3)
            },
            {
                new TreeNode(3, new TreeNode(1, right: new TreeNode(2)), new TreeNode(4)),
                new TreeNode(2),
                new TreeNode(4),
                new TreeNode(3)
            },
        };
    }
}