using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Data;
using Xunit;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(ListNode l1, ListNode l2, ListNode expectedResult);
    public static DataModel[] DataSets =>
        [DataSet_01, DataSet_02, DataSet_03];

    public static DataModel DataSet_01 => new(
        new ListNode(2, new ListNode(4, new ListNode(3))),
        new ListNode(5, new ListNode(6, new ListNode(4))),
        new ListNode(7, new ListNode(0, new ListNode(8))));

    public static DataModel DataSet_02 => new(
        new ListNode(0),
        new ListNode(0),
        new ListNode(0));

    public static DataModel DataSet_03 => new(
        new ListNode(9, 
            new ListNode(9,
                new ListNode(9, 
                    new ListNode(9, 
                        new ListNode(9, 
                            new ListNode(9, 
                                new ListNode(9))))))),
        new ListNode(9, 
            new ListNode(9, 
                new ListNode(9, 
                    new ListNode(9)))),
        new ListNode(8, 
            new ListNode(9, 
                new ListNode(9, 
                    new ListNode(9, 
                        new ListNode(0, 
                            new ListNode(0, 
                                new ListNode(0, 
                                    new ListNode(1)))))))));
}

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public bool test() { return true; }
}

public class Tests
{
    private static Solution sut = new();

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Test_1(int testIndex)
    {
        var dataSet = TestData.DataSets[testIndex];

        var result = sut.AddTwoNumbers(dataSet.l1, dataSet.l2);
        Equals(dataSet.expectedResult, result);
    }

    private void Equals(ListNode l1, ListNode l2)
    {
        Assert.Equal(l1.val, l2.val);
        if (l1.next is not null)
        {
            Assert.NotNull(l2.next);
            Equals(l1.next, l2.next);
        }
        else
            Assert.Null(l2.next);

    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return AddTwoNumbers(l1, l2, 0);
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int caryon = 0)
    {
        int sum = l1.val + l2.val + caryon;
        int value = sum % 10;
        int newCaryon = (sum / 10) % 10;
        if (l1.next is not null &&
            l2.next is not null)
            return new ListNode(value, AddTwoNumbers(l1.next, l2.next, newCaryon));
        else if (l1.next is null && l2.next is not null)
            return new ListNode(value, AddTwoNumbers(l2.next, newCaryon));
        else if (l2.next is null && l1.next is not null)
            return new ListNode(value, AddTwoNumbers(l1.next, newCaryon));
        else if(newCaryon > 0)
            return new ListNode(value, new ListNode(newCaryon));
        else
            return new ListNode(value);
    }

    public ListNode AddTwoNumbers(ListNode l1, int caryon = 0)
    {
        int sum = l1.val + caryon;
        int value = sum % 10;
        int newCaryon = (sum / 10) % 10;
        if (l1.next is not null)
            return new ListNode(value, AddTwoNumbers(l1.next, newCaryon));
        else if (newCaryon > 0)
            return new ListNode(value, new ListNode(newCaryon));
        else
            return new ListNode(value);
    }
}

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}