﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmarks>();

public static class TestData
{
    public record DataModel(int[] Nums1, int[] Nums2, double ExpectedResult);

    public static DataModel[] DataSets => [DataSet_01, DataSet_02, DataSet_03, DataSet_04, DataSet_05];

    public static DataModel DataSet_01 = new([1,3], [2], 2.0);
    public static DataModel DataSet_02 = new([1, 2], [3, 4], 2.5);
    public static DataModel DataSet_03 = new([1], [], 1.0);
    public static DataModel DataSet_04 = new([1], [2], 1.5);
    public static DataModel DataSet_05 = new([1, 3], [], 2);

    public static DataModel DataSet_long = new(
        [-106, -106, -106, -106, -106, -105, -105, -105, -105, -105, -104, -104, -104, -103, -103, -103, -103, -103, -103, -102, -102, -102, -102, -101, -101, -101, -101, -101, -101, -101, -101, -101, -100, -100, -100, -100, -99, -99, -99, -99, -98, -98, -98, -98, -98, -97, -97, -97, -97, -97, -97, -97, -97, -97, -96, -96, -96, -95, -95, -95, -95, -95, -95, -95, -94, -93, -93, -93, -93, -93, -92, -91, -91, -91, -91, -91, -91, -91, -90, -90, -89, -89, -89, -89, -89, -89, -89, -89, -88, -88, -88, -88, -88, -87, -86, -86, -86, -86, -86, -86, -86, -86, -85, -85, -85, -84, -84, -84, -84, -84, -84, -84, -83, -82, -82, -82, -82, -82, -81, -81, -81, -81, -80, -80, -80, -80, -79, -79, -78, -78, -78, -78, -78, -78, -78, -77, -77, -77, -77, -76, -76, -76, -76, -76, -76, -75, -75, -75, -75, -75, -75, -75, -74, -74, -74, -74, -74, -73, -73, -72, -72, -72, -72, -72, -71, -71, -71, -71, -71, -71, -71, -70, -70, -70, -70, -70, -70, -70, -70, -69, -69, -69, -69, -68, -68, -68, -68, -68, -67, -67, -67, -67, -67, -66, -66, -66, -66, -66, -66, -65, -65, -65, -65, -65, -65, -64, -64, -64, -63, -63, -63, -63, -63, -63, -62, -62, -62, -62, -62, -62, -62, -61, -61, -61, -61, -61, -60, -60, -60, -60, -59, -59, -59, -59, -59, -58, -58, -58, -58, -57, -57, -57, -57, -56, -56, -56, -55, -55, -55, -54, -54, -54, -54, -54, -53, -53, -53, -53, -52, -52, -52, -52, -52, -52, -52, -52, -51, -51, -51, -51, -50, -50, -50, -50, -50, -49, -49, -49, -49, -49, -49, -49, -48, -48, -48, -48, -46, -46, -46, -46, -46, -46, -46, -46, -46, -45, -45, -45, -45, -44, -44, -43, -43, -43, -43, -43, -43, -42, -42, -42, -42, -42, -42, -41, -41, -41, -41, -41, -40, -40, -39, -39, -39, -39, -38, -38, -38, -38, -38, -38, -37, -37, -37, -36, -36, -36, -36, -36, -36, -35, -35, -35, -35, -35, -35, -34, -34, -33, -33, -33, -33, -33, -32, -32, -32, -32, -32, -32, -32, -32, -31, -31, -31, -31, -31, -31, -31, -31, -30, -30, -30, -30, -29, -29, -29, -29, -29, -29, -29, -28, -28, -28, -28, -28, -27, -27, -27, -26, -26, -26, -26, -25, -25, -24, -24, -24, -24, -24, -24, -24, -24, -24, -23, -23, -23, -23, -22, -22, -21, -21, -21, -21, -20, -20, -20, -19, -19, -19, -19, -19, -19, -18, -18, -18, -16, -16, -16, -16, -16, -16, -16, -15, -15, -15, -15, -15, -15, -15, -14, -14, -14, -14, -14, -14, -14, -14, -14, -13, -13, -13, -13, -13, -12, -12, -12, -12, -11, -11, -11, -11, -10, -10, -10, -10, -10, -10, -10, -10, -9, -9, -9, -8, -8, -8, -8, -8, -8, -8, -8, -8, -7, -7, -7, -6, -6, -6, -6, -6, -6, -6, -6, -6, -5, -5, -5, -4, -4, -4, -4, -4, -4, -3, -3, -3, -3, -3, -3, -2, -2, -2, -2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 13, 13, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 17, 17, 17, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 21, 22, 22, 22, 23, 23, 23, 23, 24, 24, 24, 24, 24, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 29, 29, 29, 29, 29, 30, 30, 30, 30, 31, 31, 31, 31, 31, 31, 32, 32, 32, 32, 32, 33, 33, 33, 33, 33, 33, 33, 34, 34, 34, 35, 35, 35, 35, 35, 35, 36, 36, 36, 36, 36, 36, 37, 37, 38, 38, 39, 39, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 41, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 43, 44, 44, 45, 45, 45, 46, 46, 46, 46, 46, 46, 46, 47, 48, 48, 48, 48, 49, 49, 49, 49, 49, 49, 50, 50, 50, 50, 50, 50, 50, 50, 51, 52, 52, 52, 52, 53, 53, 53, 53, 53, 53, 53, 54, 54, 54, 54, 54, 55, 55, 55, 55, 55, 56, 56, 56, 56, 57, 57, 57, 57, 57, 57, 58, 58, 58, 58, 58, 58, 58, 58, 58, 59, 59, 59, 59, 59, 60, 60, 60, 61, 61, 61, 61, 62, 62, 62, 62, 63, 63, 63, 64, 64, 64, 64, 64, 64, 64, 64, 65, 65, 65, 65, 65, 65, 66, 66, 66, 66, 66, 67, 67, 67, 67, 67, 67, 67, 68, 68, 68, 69, 69, 69, 69, 69, 70, 70, 70, 70, 70, 71, 71, 71, 71, 71, 71, 72, 72, 72, 72, 72, 73, 73, 73, 73, 73, 73, 73, 74, 74, 74, 74, 74, 74, 75, 75, 75, 75, 75, 75, 75, 76, 76, 77, 77, 77, 77, 77, 77, 77, 78, 78, 78, 79, 79, 80, 80, 81, 81, 81, 81, 82, 82, 82, 82, 82, 82, 82, 82, 82, 83, 83, 83, 83, 84, 84, 85, 86, 86, 86, 86, 87, 87, 87, 87, 88, 89, 89, 89, 89, 90, 90, 90, 90, 90, 91, 91, 91, 91, 91, 92, 92, 92, 93, 93, 94, 94, 94, 95, 95, 95, 95, 95, 95, 96, 96, 96, 96, 96, 96, 97, 97, 97, 98, 98, 99, 99, 99, 100, 100, 101, 101, 101, 101, 102, 102, 103, 103, 103, 103, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 105, 105, 105, 105, 105],
        [-106, -106, -106, -106, -106, -106, -106, -105, -105, -105, -105, -105, -105, -105, -104, -104, -104, -103, -103, -103, -102, -102, -102, -102, -102, -101, -101, -101, -101, -101, -100, -100, -100, -100, -100, -99, -99, -98, -98, -97, -97, -97, -97, -96, -96, -96, -96, -96, -96, -95, -95, -95, -95, -95, -95, -94, -94, -94, -94, -94, -93, -92, -92, -92, -92, -92, -91, -91, -91, -91, -90, -90, -89, -89, -89, -88, -88, -88, -88, -88, -87, -87, -86, -86, -86, -86, -86, -86, -86, -86, -86, -86, -86, -85, -85, -85, -85, -85, -85, -84, -84, -84, -84, -84, -84, -83, -83, -83, -83, -83, -83, -82, -81, -81, -81, -81, -80, -80, -80, -80, -79, -79, -79, -79, -79, -79, -78, -78, -77, -77, -77, -77, -77, -77, -76, -76, -76, -76, -75, -75, -75, -75, -75, -75, -75, -75, -75, -75, -75, -74, -74, -74, -74, -74, -74, -74, -74, -74, -74, -73, -73, -73, -72, -72, -72, -72, -72, -72, -72, -72, -72, -72, -71, -71, -71, -71, -71, -70, -70, -70, -70, -69, -69, -69, -68, -68, -68, -68, -68, -68, -67, -67, -67, -67, -67, -67, -67, -67, -67, -66, -66, -66, -66, -66, -66, -66, -66, -66, -65, -65, -65, -65, -65, -65, -64, -64, -64, -64, -64, -64, -63, -63, -63, -63, -62, -62, -62, -62, -61, -61, -61, -60, -60, -60, -60, -60, -60, -59, -59, -59, -59, -59, -59, -59, -58, -58, -58, -58, -58, -57, -57, -57, -56, -56, -56, -56, -55, -55, -55, -54, -54, -54, -53, -53, -53, -53, -52, -52, -52, -52, -51, -51, -51, -51, -51, -51, -51, -51, -50, -50, -49, -49, -49, -49, -48, -48, -48, -48, -47, -47, -47, -47, -47, -47, -47, -46, -45, -45, -44, -44, -44, -44, -43, -43, -43, -43, -43, -42, -42, -42, -41, -41, -41, -41, -41, -41, -40, -40, -40, -40, -40, -39, -39, -38, -38, -38, -38, -38, -38, -38, -38, -38, -38, -38, -37, -37, -37, -37, -37, -36, -36, -36, -35, -35, -35, -35, -35, -35, -35, -35, -35, -35, -35, -35, -35, -34, -34, -34, -34, -34, -34, -34, -33, -33, -33, -32, -32, -32, -32, -32, -32, -32, -32, -32, -31, -31, -31, -31, -31, -31, -30, -30, -30, -30, -30, -29, -28, -28, -28, -28, -28, -27, -27, -27, -26, -26, -26, -26, -25, -25, -24, -24, -24, -24, -24, -23, -23, -23, -23, -22, -22, -22, -22, -21, -21, -21, -21, -21, -21, -21, -21, -21, -21, -21, -20, -20, -20, -20, -20, -19, -19, -19, -19, -18, -18, -18, -17, -17, -17, -16, -16, -16, -16, -16, -16, -15, -15, -15, -15, -15, -15, -14, -14, -14, -13, -13, -13, -13, -12, -12, -12, -12, -12, -12, -12, -12, -12, -11, -11, -11, -11, -10, -10, -10, -10, -10, -10, -9, -9, -8, -8, -8, -8, -8, -8, -8, -8, -7, -7, -7, -6, -6, -6, -6, -5, -5, -5, -4, -3, -3, -2, -2, -1, -1, -1, -1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 11, 11, 11, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 15, 15, 16, 16, 16, 16, 17, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 20, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22, 23, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 27, 27, 27, 27, 27, 28, 28, 28, 28, 29, 29, 29, 29, 30, 30, 30, 31, 31, 31, 31, 31, 31, 31, 31, 32, 32, 32, 33, 33, 33, 33, 33, 33, 34, 34, 35, 35, 35, 35, 35, 35, 36, 36, 36, 36, 36, 37, 37, 37, 37, 37, 37, 37, 37, 37, 38, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 42, 42, 43, 43, 43, 43, 43, 44, 44, 44, 45, 45, 46, 46, 46, 46, 47, 47, 47, 47, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 49, 49, 49, 50, 50, 50, 51, 51, 52, 52, 52, 52, 52, 52, 52, 53, 53, 53, 53, 53, 53, 53, 54, 54, 55, 55, 55, 55, 56, 56, 57, 57, 57, 57, 57, 57, 57, 58, 58, 59, 59, 59, 59, 59, 60, 60, 60, 61, 61, 61, 61, 61, 61, 62, 62, 62, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 64, 64, 64, 64, 65, 65, 65, 66, 66, 66, 66, 66, 66, 66, 67, 67, 67, 67, 67, 67, 68, 68, 68, 68, 68, 68, 68, 69, 69, 69, 69, 70, 70, 70, 70, 70, 70, 70, 70, 71, 71, 71, 71, 71, 71, 71, 72, 72, 72, 72, 72, 73, 73, 74, 74, 74, 74, 74, 75, 75, 75, 75, 75, 76, 76, 76, 77, 77, 77, 77, 77, 77, 77, 77, 77, 77, 78, 78, 78, 78, 78, 79, 79, 79, 79, 80, 80, 80, 80, 81, 81, 81, 81, 81, 81, 81, 81, 81, 82, 82, 82, 82, 82, 83, 83, 83, 84, 84, 84, 85, 85, 85, 85, 85, 85, 86, 86, 86, 87, 87, 87, 87, 88, 88, 88, 88, 88, 88, 89, 89, 89, 89, 89, 89, 89, 89, 90, 90, 90, 90, 90, 90, 90, 91, 91, 91, 91, 91, 92, 92, 92, 92, 93, 93, 93, 93, 94, 94, 94, 94, 94, 94, 95, 95, 95, 95, 95, 96, 96, 96, 97, 97, 97, 97, 98, 98, 98, 98, 98, 99, 99, 99, 99, 100, 100, 100, 100, 100, 100, 100, 100, 101, 101, 101, 101, 103, 103, 103, 103, 103, 104, 105, 105, 105, 105, 105],
        -3);
}

[MemoryDiagnoser]
public class Benchmarks
{
    static Solution _sut = new Solution();

    [Benchmark]
    public double test_span() { return _sut.FindMedianSortedArrays(TestData.DataSet_long.Nums1, TestData.DataSet_long.Nums2); }

    [Benchmark]
    public double test_array() { return _sut.FindMedianSortedArrays(TestData.DataSet_long.Nums1, TestData.DataSet_long.Nums2); }

    [Benchmark]
    public double test_exampleSolution() { return _sut.FindMedianSortedArraysExampleSolution(TestData.DataSet_long.Nums1, TestData.DataSet_long.Nums2); }

}

public class Tests
{
    static Solution _sut = new Solution();

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Test_1(int testIndex) 
    {
        var testData = TestData.DataSets[testIndex];
        var result = _sut.FindMedianSortedArrays(testData.Nums1, testData.Nums2);
        Assert.Equal(testData.ExpectedResult, result);
    }

    [Fact]
    public void TestLong()
    {
        var testData = TestData.DataSet_long;
        var result = _sut.FindMedianSortedArrays(testData.Nums1, testData.Nums2);
        Assert.Equal(testData.ExpectedResult, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Test_1ExampleSolution(int testIndex)
    {
        var testData = TestData.DataSets[testIndex];
        var result = _sut.FindMedianSortedArraysExampleSolution(testData.Nums1, testData.Nums2);
        Assert.Equal(testData.ExpectedResult, result);
    }

    [Fact]
    public void TestLongExampleSolution()
    {
        var testData = TestData.DataSet_long;
        var result = _sut.FindMedianSortedArraysExampleSolution(testData.Nums1, testData.Nums2);
        Assert.Equal(testData.ExpectedResult, result);
    }
}

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        return FindMedianSortedArrays(nums1.AsSpan(), nums2.AsSpan());
    }

    public double FindMedianSortedArrays_Array(int[] nums1, int[] nums2)
    {
        int length = nums1.Length + nums2.Length;
        if (length == 1)
            if (nums1.Length == 1)
                return nums1[0];
            else
                return nums2[0];

        double midDouble = length / 2.0;
        int midInt = Convert.ToInt32(Math.Ceiling(midDouble));
        bool isEven = midDouble == midInt;

        int num1Index = 0;
        int num2Index = 0;
        int prevValue = 0;
        int currentValue = 0;

        if (isEven)
            midInt += 1;
        while (true)
        {
            if (num2Index == nums2.Length ||
                (num1Index < nums1.Length &&
                nums1[num1Index] <= nums2[num2Index]))
            {
                prevValue = currentValue;
                currentValue = nums1[num1Index];
                num1Index++;
            }
            else
            {
                prevValue = currentValue;
                currentValue = nums2[num2Index];
                num2Index++;
            }

            if (num1Index + num2Index >= midInt)
                break;
        }

        if (isEven)
            return (prevValue + currentValue) / 2.0;
        else
            return currentValue;
    }

    // TODO
    // Try to calculate the starting potison instead of looping troug the arrays
    public double FindMedianSortedArrays_Complex(ReadOnlySpan<int> nums1, ReadOnlySpan<int> nums2)
    {
        int length = nums1.Length + nums2.Length;
        if (length == 0)
            return 0.0;

        if (length == 1)
            if (nums1.Length == 1)
                return nums1[0];
            else
                return nums2[0];

        double midDouble = length / 2.0;
        int midInt = Convert.ToInt32(Math.Ceiling(midDouble));
        bool isEven = midDouble == midInt;

        int num1Index = 0;
        int num2Index = 0;
        int prevValue = 0;
        int currentValue = 0;

        if (isEven)
            midInt += 1;
        while (true)
        {
            if (num2Index == nums2.Length ||
                (num1Index < nums1.Length &&
                nums1[num1Index] <= nums2[num2Index]))
            {
                prevValue = currentValue;
                currentValue = nums1[num1Index];
                num1Index++;
            }
            else
            {
                prevValue = currentValue;
                currentValue = nums2[num2Index];
                num2Index++;
            }

            if (num1Index + num2Index >= midInt)
                break;
        }

        if (isEven)
            return (prevValue + currentValue) / 2.0;
        else
            return currentValue;
    }

    public double FindMedianSortedArrays(ReadOnlySpan<int> nums1, ReadOnlySpan<int> nums2)
    {
        int length = nums1.Length + nums2.Length;
        if (length == 1)
            if (nums1.Length == 1)
                return nums1[0];
            else
                return nums2[0];

        double midDouble = length / 2.0;
        int midInt = Convert.ToInt32(Math.Ceiling(midDouble));
        bool isEven = midDouble == midInt;

        int num1Index = 0;
        int num2Index = 0;
        int prevValue = 0;
        int currentValue = 0;

        if (isEven)
            midInt += 1;
        while (true)
        {
            if (num2Index == nums2.Length ||
                (num1Index < nums1.Length &&
                nums1[num1Index] <= nums2[num2Index]))
            {
                prevValue = currentValue;
                currentValue = nums1[num1Index];
                num1Index++;
            }
            else
            {
                prevValue = currentValue;
                currentValue = nums2[num2Index];
                num2Index++;
            }

            if (num1Index + num2Index >= midInt)
                break;
        }

        if (isEven)
            return (prevValue + currentValue) / 2.0;
        else
            return currentValue;
    }

    public double FindMedianSortedArraysExampleSolution(int[] nums1, int[] nums2)
    {
        List<int> merged = new List<int>();
        int i = 0, j = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                merged.Add(nums1[i++]);
            }
            else
            {
                merged.Add(nums2[j++]);
            }
        }

        while (i < nums1.Length) merged.Add(nums1[i++]);
        while (j < nums2.Length) merged.Add(nums2[j++]);

        int mid = merged.Count / 2;
        if (merged.Count % 2 == 0)
        {
            return (merged[mid - 1] + merged[mid]) / 2.0;
        }
        else
        {
            return merged[mid];
        }
    }
}