namespace LeetCode.Tasks;

/*
 * Lowest Common Ancestor of a Binary Search Tree
 * https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/description/
 *
 * Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.
 * According to the definition of LCA on Wikipedia:
 * “The lowest common ancestor is defined between two nodes p and q as the lowest node in T
 * that has both p and q as descendants (where we allow a node to be a descendant of itself).”
 *
 * Наименьший общий предок в Двоичном Дереве Поиска
 * Дано BST, найти наименьшего общего предка 2х данных нод
 *
 * Наименьший общий предок определяется между двумя нодами p и q как наименьшая нода в дереве,
 * которая имеет оба p и q как потомков (где мы позволяем ноде быть потомком себя)
 *
 */
public class LowestCommonAncestorOfABinarySearchTree
{
    private TreeNode? lowest = null;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var leftNode = p.val < q.val ? p : q;
        var rightNode = leftNode == p ? q : p;

        if (
            (root.left?.val == leftNode.val && root.right?.val == rightNode.val)
            || root.val == leftNode.val
            || root.val == rightNode.val
        )
        {
            return root;
        }

        var nextNode = p.val > root.val && q.val > root.val ? root.right : root.left;

        return LowestCommonAncestor(nextNode!, p, q);
    }
}

public class TreeNode(int x, TreeNode? left = null, TreeNode? right = null)
{
    public int val = x;
    public TreeNode? left = left;
    public TreeNode? right = right;
}