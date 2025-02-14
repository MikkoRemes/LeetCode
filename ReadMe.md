
# Problemsets

1. [x] :green_heart: 0001 Two Sum
1. [ ] :yellow_heart: 0002 Add Two Numbers
1. [ ] :yellow_heart: 0003 Longest Substring Withjout Repeating Characters
1. [ ] :heart: 0004 Median of Two Sorted Arrays

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