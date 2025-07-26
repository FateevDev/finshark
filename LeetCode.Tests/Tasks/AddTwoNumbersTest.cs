using JetBrains.Annotations;
using LeetCode.Tasks;

namespace LeetCode.Tests.Tasks;

[TestSubject(typeof(AddTwoNumbers))]
public class AddTwoNumbersTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Add_WhenCalled_ReturnsExpectedResult(ListNode l1, ListNode l2, ListNode expected)
    {
        var sut = new AddTwoNumbers();

        var result = sut.Add(l1, l2);

        Assert.Equal(expected, result);
    }

    public static TheoryData<ListNode, ListNode, ListNode> TestData()
    {
        return new TheoryData<ListNode, ListNode, ListNode>
        {
            /*
             * Explanation: 342 + 465 = 807.
             */
            {
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))),
                new ListNode(7, new ListNode(0, new ListNode(8)))
            },
            /*
             * Explanation: 0 + 0 = 0.
             */
            {
                new ListNode(0),
                new ListNode(0),
                new ListNode(0)
            },
            /*
             * Explanation: 9,999,999 + 9999 = 10,009,998.
             */
            {
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
                new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))
            },
        };
    }
}