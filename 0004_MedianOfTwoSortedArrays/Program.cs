using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(int[] Nums1, int[] Nums2, double ExpectedResult);

    public static DataModel[] DataSets => [DataSet_01, DataSet_02];

    public static DataModel DataSet_01 = new([1,3], [2], 2.0);
    public static DataModel DataSet_02 = new([1, 2], [3, 4], 2.5);
}

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public bool test() { return true; }
}

public class Tests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Test_1(int testIndex) 
    {

    }

    [Fact]
    public void TestLong() 
    {

    }
}

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        return 0.0;
    }
}