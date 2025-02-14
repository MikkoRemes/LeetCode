
# Problemsets

1. [x] Two Sum
1. [ ] Add Two Numbers
1. [ ] Longest Substring Withjout Repeating Characters
1. [ ] Median of Two Sorted Arrays

# Base program

```csharp

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
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
    public void Test_1(int testIndex) { }

    [Fact]
    public void TestLong() { }
}

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        return 0.0;
    }
}

```