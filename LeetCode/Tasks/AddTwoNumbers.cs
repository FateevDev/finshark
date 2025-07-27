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
 *
 * Краткое описание решения:
 * Рекурсивно обрабатываем сложение (как сложение "столбиком")
 * Если сумма чисел больше 10, то переносим единичку в следующий порядок
 *
 * Сложность:
 * По времени: O(max(n, m)), где n и m - длины входных списков
 * По памяти: O(max(n, m)) - стек вызовов + результирующий список
 */
public class AddTwoNumbers
{
    public ListNode Add(ListNode l1, ListNode l2)
    {
        var result = AddRecursive(l1, l2, 0);

        return result;
    }

    private ListNode AddRecursive(ListNode? l1, ListNode? l2, int carry)
    {
        var sum = (l1?.Val ?? 0) + (l2?.Val ?? 0) + carry;
        var newCarry = sum / 10;
        var resultNode = new ListNode(sum % 10);

        if (l1?.Next != null || l2?.Next != null || newCarry != 0)
        {
            resultNode.Next = AddRecursive(l1?.Next, l2?.Next, newCarry);
        }

        return resultNode;
    }
}

public class ListNode(int val, ListNode? next = null)
{
    public int Val = val;
    public ListNode? Next = next;

    public override string ToString()
    {
        if (Next != null)
        {
            return $"{Next}{Val}";
        }

        return $"{Val}";
    }
}