using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace BasicHttpBindingService;

public class SearchService : ISearchService
{
    public int FindSimple( int value)
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (var i = 0; i < data.Length; i++)
            if (data[i] == value)
            {
                Console.WriteLine($"Found number: {i}");
                return i;
            }

        return -1;
    }

    public int Find_Generic_128_(int[] data, int value)
    {
        // In theory we should check for Vector128.IsHardwareAccelerated and dispatch
        // accordingly, in practice here we don't to keep the code simple.
        var vInts = MemoryMarshal.Cast<int, Vector128<int>>(data);

        var compareValue = Vector128.Create(value);
        var vectorLength = Vector128<int>.Count;

        // Batch <4 x int> per loop
        for (var i = 0; i < vInts.Length; i++)
        {
            var result = Vector128.Equals(vInts[i], compareValue);
            if (result == Vector128<int>.Zero) continue;

            for (var k = 0; k < vectorLength; k++)
                if (result.GetElement(k) != 0)
                    return i * vectorLength + k;
        }

        // Scalar process of the remaining
        for (var i = vInts.Length * vectorLength; i < data.Length; i++)
            if (data[i] == value)
                return i;

        return -1;
    }

    public int Find_Generic_256_(int[] data, int value)
    {
        // In theory we should check for Vector256.IsHardwareAccelerated and dispatch
        // accordingly, in practice here we don't to keep the code simple.
        var vInts = MemoryMarshal.Cast<int, Vector256<int>>(data);

        var compareValue = Vector256.Create(value);
        var vectorLength = Vector256<int>.Count;

        // Batch <8 x int> per loop
        for (var i = 0; i < vInts.Length; i++)
        {
            var result = Vector256.Equals(vInts[i], compareValue);
            if (result == Vector256<int>.Zero) continue;

            for (var k = 0; k < vectorLength; k++)
                if (result.GetElement(k) != 0)
                    return i * vectorLength + k;
        }

        // Scalar process of the remaining
        for (var i = vInts.Length * vectorLength; i < data.Length; i++)
            if (data[i] == value)
                return i;

        return -1;
    }
}