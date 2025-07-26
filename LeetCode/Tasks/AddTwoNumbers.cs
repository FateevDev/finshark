namespace LeetCode.Tasks;

/*
 * Add Two Numbers https://leetcode.com/problems/add-two-numbers/description/
 * 
 * You are given two non-empty linked-lists representing two non-negative integers.
 * The digits are stored in reverse order, and each of their nodes contains a single digit.
 * Add the two numbers and return the sum as a linked list.
 * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
 * 
 * Constraints:
 * The number of nodes in each linked list is in the range [1, 100].
 * 0 <= Node.val <= 9
 * It is guaranteed that the list represents a number that does not have leading zeros.
 * 
 *
 * Даны два непустых связных списка представляющих 2 положительных числа
 * Цифры хранятся к обратном порядке, и каждая из нод содержит одну цифру
 * Нужно сложить эти два числа и вернуть результат в виде связанного списка.
 * 2 числа не содержат лидирующий 0, кроме если число - 0
 */
public class AddTwoNumbers
{
    public ListNode Add(ListNode l1, ListNode l2)
    {
        return new ListNode();
    }
}

public class ListNode(int val = 0, ListNode? next = null)
{
    public int Val = val;
    public ListNode? Next = next;
}