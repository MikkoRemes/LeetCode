using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(int[] ints, int target, int[] excpectedResult);
    public static DataModel[] tests => [test_01, test_02, test_03, test_04, test_05, test_06, test_07, test_08, test_09, test_10];

    public static DataModel test_01 = new([2, 7, 11, 15], 2 + 7, [0, 1]);
    public static DataModel test_02 = new([2, 7, 11, 15], 2 + 11, [0, 2]);
    public static DataModel test_03 = new([2, 7, 11, 15], 2 + 15, [0, 3]);

    public static DataModel test_04 = new([2, 7, 11, 15], 7 + 11, [1, 2]);
    public static DataModel test_05 = new([2, 7, 11, 15], 7 + 15, [1, 3]);

    public static DataModel test_06 = new([2, 7, 11, 15], 11 + 15, [2, 3]);
    
    // These should not be successfull since it shoudl only sum two numbers
    public static DataModel test_07 = new([2, 7, 11, 15], 2 + 7 + 11, [0, 1, 2]);
    public static DataModel test_08 = new([2, 7, 11, 15], 2 + 7 + 15, [0, 1, 3]);
    public static DataModel test_09 = new([2, 7, 11, 15], 2 + 11 + 15, [0, 2, 3]);
    public static DataModel test_10 = new([2, 7, 11, 15], 7 + 11 + 15, [1, 2, 3]);

    public static DataModel test_long = new(
        [ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97], 
        11 + 31 + 53 + 83, 
        [0, 1, 2, 3, 4, 5, 6, 7, 8 , 10, 14]);
}

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public int[] Sum()
    {
        return Solution.TwoSum(TestData.test_01.ints, TestData.test_01.target);
    }

    [Benchmark]
    public int[] SumLong()
    {
        return Solution.TwoSum(TestData.test_01.ints, TestData.test_01.target);
    }
}

public class Tests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    public void Test_1(int testIndex)
    {
        var result = Solution.TwoSum(TestData.tests[testIndex].ints, TestData.tests[testIndex].target);
        Assert.Equal(TestData.tests[testIndex].excpectedResult, result);
    }

    [Fact]
    public void TestLong()
    {
        var result = Solution.TwoSum(TestData.test_long.ints, TestData.test_long.target);
        Assert.Equal(TestData.test_long.excpectedResult, result);
    }
}

public static class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        ReadOnlySpan<int> ints = new ReadOnlySpan<int>(nums);
        Span<int> result = stackalloc int[nums.Length];
        TwoSum(ints, target, result, 0, 0, 0, out int depth);
        return result[..depth].ToArray();
    }

    public static bool TwoSum(ReadOnlySpan<int> ints, int target, Span<int> result, int currentStart, int sum, int depthSoFar, out int depth)
    {
        for (int i = currentStart; i < ints.Length; i++)
        {
            int currentValue = ints[i];
            var currentSum = sum + currentValue;
            result[depthSoFar] = i;
            depth = depthSoFar + 1;
            if (currentSum > target)
                return false;
            if (currentSum == target)
                return true;
            if (TwoSum(ints, target, result, i + 1, currentSum, depth, out depth))
                return true;
        }
        depth = -1;
        return false;
    }
}