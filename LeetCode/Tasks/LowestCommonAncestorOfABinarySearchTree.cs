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
 * Описание решения:
 * Решение основано на свойстве BST:
 * - все значения а левом поддереве меньше текущей ноды
 * - все значения а правом поддереве больше текущей ноды
 *
 * Можно решить рекурсией, а можно итеративно (как и любую рекурсивную задачу)
 * Итеративное решение лучше, т.к. нет расхода памяти на рекурсию
 *
 * Примеры
 *   Корректное BST
 *      8
 *     / \
 *    3   10
 *   / \    \
 *  1   6    14
 *     / \   /
 *    4   7 13
 *
 *  Некорректное BST
 *        8            ← корень
 *      /   \
 *     3      10       ← всё что слева от 8 должно быть < 8
 *    / \       \
 *   1   6       14
 *      / \      /
 *     4   7   13
 *    /     \
 *   3       10        ← эта 10 в левом поддереве от корня 8!
 *
 * Т.к. BST упорядочено, достаточно сравнивать только значения нод:
 * Если оба значения меньше текущей ноды, значит, идем влево
 * Если оба значения больше текущей ноды, значит, идем право
 * Иначе - мы нашли наименьшего общего предка, т.к. нашли разветвление в BST
 *
 * Сложность:
 * По времени O(log n)
 * По памяти O(1)
 */
public class LowestCommonAncestorOfABinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (p.val > root.val && q.val > root.val)
        {
            return LowestCommonAncestor(root.right!, p, q);
        }

        if (p.val < root.val && q.val < root.val)
        {
            return LowestCommonAncestor(root.left!, p, q);
        }

        return root;
    }

    public TreeNode? LowestCommonAncestorIterative(TreeNode? root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (p.val > root.val && q.val > root.val)
            {
                root = root.right!;
            }
            else if (p.val < root.val && q.val < root.val)
            {
                root = root.left!;
            }
            else
            {
                return root;
            }
        }

        return null;
    }
}

public class TreeNode(int x, TreeNode? left = null, TreeNode? right = null)
{
    public int val = x;
    public TreeNode? left = left;
    public TreeNode? right = right;
}