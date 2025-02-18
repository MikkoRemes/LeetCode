using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;
using static TestData;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(string S, string A, bool IsMatch);
    public static DataModel[] DataSets => 
        [DataSet_01, DataSet_02, DataSet_03, DataSet_04, DataSet_05, DataSet_06, DataSet_07, DataSet_08, DataSet_09, DataSet_10,
         DataSet_11, DataSet_12, DataSet_13, DataSet_14, DataSet_15, DataSet_16, DataSet_17, DataSet_18, DataSet_19];

    public static DataModel DataSet_01 = new("aa", "a", false);
    public static DataModel DataSet_02 = new("aa", "a*", true);
    public static DataModel DataSet_03 = new("ab", ".*", true);
    public static DataModel DataSet_04 = new("abbaacdc", "a*..aa*.dc", true);
    public static DataModel DataSet_05 = new("abbaacdc", "a.aa.dc", false);
    public static DataModel DataSet_06 = new("abbaacdc", "a..aa.dc", true);
    public static DataModel DataSet_07 = new("abbaacdc", "abba*acdc", true);
    public static DataModel DataSet_08 = new("abcd", "efg*", false);
    public static DataModel DataSet_09 = new("aab", "c*a*b", true);
    public static DataModel DataSet_10 = new("mississippi", "mis*is*p*.", false);
    public static DataModel DataSet_11 = new("aaa", "a*aa", true);
    public static DataModel DataSet_12 = new("aaa", "a*aaa", true);
    public static DataModel DataSet_13 = new("aaa", "a*aaaa", false);
    public static DataModel DataSet_14 = new("baaa", "ba*aaaa", false);
    public static DataModel DataSet_15 = new("ab", ".*c", false);
    public static DataModel DataSet_16 = new("aaa", "aaaa", false);
    public static DataModel DataSet_17 = new("aaa", ".*", true);
    public static DataModel DataSet_18 = new("aaa", "**", true);
    public static DataModel DataSet_19 = new("a", "ab*a", false);

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
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
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
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
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
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
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
            if (i < p.Length - 1 && p[i + 1] == MATCHZEROORMORE)
            {
                if (p[i] == MATCHSINGLE)
                    if (i == p.Length - 2)
                        return true;
                    else
                    {
                        i++;
                        continue;
                    }

                while (j < s.Length && s[j] == p[i])
                    j++;

                for (int k = i + 2; k < p.Length; k++)
                    if (p[k] == p[i])
                        j--;
                    else
                        break;

                if (j < 0)
                    return false;

                if (j >= s.Length)
                    return true;// i < p.Length - 2;

                i++;
                continue;
            }

            else if (p[i] == MATCHSINGLE)
            {
                j++;
                continue;
            }

            if (j >= s.Length)
                return false;
            if (s[j] != p[i])                
                return false;

            j++;
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