using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Runtime.Utilities;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(int[] ints, int target, int[] excpectedResult);
    public static DataModel[] tests => [test_01, test_02, test_03, test_04, test_05, test_06];

    public static DataModel test_01 = new([2, 7, 11, 15], 2 + 7, [0, 1]);
    public static DataModel test_02 = new([2, 7, 11, 15], 2 + 11, [0, 2]);
    public static DataModel test_03 = new([2, 7, 11, 15], 2 + 15, [0, 3]);

    public static DataModel test_04 = new([2, 7, 11, 15], 7 + 11, [1, 2]);
    public static DataModel test_05 = new([2, 7, 11, 15], 7 + 15, [1, 3]);

    public static DataModel test_06 = new([2, 7, 11, 15], 11 + 15, [2, 3]);

    public static DataModel test_long = new(
        [ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, -109, 109], 
        0, 
        [23, 24]);
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
        int[] result = new int[2];
        for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
        return result;
    }
}