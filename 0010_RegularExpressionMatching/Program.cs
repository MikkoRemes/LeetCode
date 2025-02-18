using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;
using static TestData;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(string S, string A, bool IsMatch);
    public static DataModel[] DataSets => [DataSet_01, DataSet_02, DataSet_03, DataSet_04, DataSet_05, DataSet_06, DataSet_07, DataSet_08, DataSet_09];

    public static DataModel DataSet_01 = new("aa", "a", false);
    public static DataModel DataSet_02 = new("aa", "a*", true);
    public static DataModel DataSet_03 = new("ab", ".*", true);
    public static DataModel DataSet_04 = new("abbaacdc", "a*..aa*.dc", true);
    public static DataModel DataSet_05 = new("abbaacdc", "a.aa.dc", false);
    public static DataModel DataSet_06 = new("abbaacdc", "a..aa.dc", true);
    public static DataModel DataSet_07 = new("abbaacdc", "abba*acdc", true);
    public static DataModel DataSet_08 = new("abcd", "efg*", false);
    public static DataModel DataSet_09 = new("aab", "c*a*b", true);
    public static DataModel DataSet_10 = new("mississippi", "mis*is*p*.", true);

    public static DataModel DataSet_long = new("abcdefghijabcdefghij", "a*bcdefghijab*cdefghij", true);
}

[MemoryDiagnoser]
public class Benchmarks
{
    Solution _sut = new Solution();

    [Benchmark]
    public bool test() { return _sut.IsMatch(TestData.DataSet_long.S, TestData.DataSet_long.A); }

    [Benchmark]
    public bool testExampleSolution() { return _sut.IsMatchExampleSolution(TestData.DataSet_long.S, TestData.DataSet_long.A); }

    [Benchmark]
    public bool testRegEx() { return _sut.IsMatchRegEx(TestData.DataSet_long.S, TestData.DataSet_long.A); }
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
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
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

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void Test_1RegEx(int testIndex)
    {
        DataModel testData = TestData.DataSets[testIndex];
        var result = _sut.IsMatchRegEx(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);
    }

    [Fact]
    public void TestLongRegEx()
    {
        DataModel testData = TestData.DataSet_long;
        var result = _sut.IsMatchRegEx(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void Test_1ExampleSolution(int testIndex)
    {
        DataModel testData = TestData.DataSets[testIndex];
        var result = _sut.IsMatchExampleSolution(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);
    }

    [Fact]
    public void TestLongExampleSolution()
    {
        DataModel testData = TestData.DataSet_long;
        var result = _sut.IsMatchExampleSolution(testData.S, testData.A);
        Assert.Equal(testData.IsMatch, result);
    }
}

public class Solution
{
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
                if (i == 0)
                    return false;

                if (p[i - 1] == MATCHSINGLE)
                    return true;

                while (j < s.Length)
                    if (s[j] != p[i-1])
                        break;
                    else
                        j++;

                for (int k = i + 1; k < p.Length; k++)
                    if (p[k] == p[i - 1])
                        j--;
                    else
                        break;

                continue;
            }

            if (s[j] != p[i])
                if(i >= p.Length || p[i + 1] != MATCHZEROORMORE)
                    return false;

            j++;
            if (j > s.Length)
                return false;
        }

        return j == s.Length;
    }

    public bool IsMatchRegEx(string s, string p)
    {
        if (p.Contains("**"))
            return true;
        return Regex.IsMatch(s, "^" + p + "$");
    }

    public bool IsMatchExampleSolution(string s, string p)
    {
        bool[,] mat = new bool[s.Length + 1, p.Length + 1];

        mat[0, 0] = true;

        for (int i = 1; i < mat.GetLength(1); i++)
        {
            if (p[i - 1] == '*')
            {
                mat[0, i] = mat[0, i - 2];
            }
        }

        for (int i = 1; i < mat.GetLength(0); i++)
        {
            for (int j = 1; j < mat.GetLength(1); j++)
            {
                if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                {
                    mat[i, j] = mat[i - 1, j - 1];
                }
                else if (p[j - 1] == '*')
                {
                    mat[i, j] = mat[i, j - 2];
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                    {
                        mat[i, j] = mat[i, j] || mat[i - 1, j];
                    }
                }
                else
                {
                    mat[i, j] = false;
                }
            }
        }

        return mat[s.Length, p.Length];
    }
}