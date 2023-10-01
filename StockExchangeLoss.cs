using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');

        foreach (var input in inputs)
        {
            Console.Error.WriteLine($"{input}");
        }
        int[] stockValues = new int[]{ 0, 0};
        bool isFirstValue = true;

        for (int i = 0; i < n; i++)
        {
            int v = int.Parse(inputs[i]);
            isFirstValue = AddFirstValue(isFirstValue, stockValues, v);
            Console.Error.WriteLine($"{stockValues[0]}");
        }

        Console.WriteLine("answer");
    }

    private static bool AddFirstValue(bool isFirstValue, int[] stockValues, int v)
    {
        if (IsFirstValue(isFirstValue))
        {
            stockValues[0] = v;
            isFirstValue = false;
        }

        return isFirstValue;
    }

    private static bool IsFirstValue(bool isFirstValue) => isFirstValue == true;
}

