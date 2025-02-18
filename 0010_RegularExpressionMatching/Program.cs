using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;
using static TestData;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(string S, string A, bool IsMatch);
    public static DataModel[] DataSets => [DataSet_01, DataSet_02, DataSet_03, DataSet_04, DataSet_05, DataSet_06, DataSet_07, DataSet_08];

    public static DataModel DataSet_01 = new("aa", "a", false);
    public static DataModel DataSet_02 = new("aa", "a*", true);
    public static DataModel DataSet_03 = new("ab", ".*", true);
    public static DataModel DataSet_04 = new("abbaacdc", "a*aa*dc", true);
    public static DataModel DataSet_05 = new("abbaacdc", "a.aa.dc", false);
    public static DataModel DataSet_06 = new("abbaacdc", "a..aa.dc", true);
    public static DataModel DataSet_07 = new("abbaacdc", "abba*acdc", true);
    public static DataModel DataSet_08 = new("abcd", "efg*", false);

    public static DataModel DataSet_long = new("abcdefghijabcdefghij", "*hijab*", true);
}

[MemoryDiagnoser]
public class Benchmarks
{
    Solution _sut = new Solution();

    [Benchmark]
    public bool test() { return _sut.IsMatch(TestData.DataSet_long.S, TestData.DataSet_long.A); }
}

public class Tests
{
    Solution _sut = new Solution();

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void Test_1(int testIndex) 
    {
        DataModel testData = TestData.DataSets[testIndex];
        var result = _sut.IsMatch(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);
    }

    [Fact]
    public void TestLong() 
    {
        DataModel testData = TestData.DataSet_long;
        var result = _sut.IsMatch(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);

    }
}

public class Solution
{
    // TODO This fails. It will give match
    //Regex regex = new(p);
    //return regex.IsMatch(s);

    private const char MATCHSINGLE = '.';
    private const char MATCHZEROORMORE = '*';

    public bool IsMatch(string s, string p)
    {
        return IsMatchSpan(s, p);
    }

    public bool IsMatchSpan(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
    {
        int j = 0;
        for(int i = 0; i < p.Length; i++)
        {

            if (p[i] == MATCHSINGLE)
            {
                j++;
                continue;
            }

            if (p[i] == MATCHZEROORMORE)
            {
                // Last pattern char is zero or more
                if (i == p.Length - 1)
                    return true;

                i++;
                while (j < s.Length)
                    if (s[j++] == p[i])
                        goto end;

                return false;
            }

            if (s[j] != p[i])
                return false;

            j++;
            if (j > s.Length)
                return false;

            end:;
        }

        return j == s.Length;
    }
}