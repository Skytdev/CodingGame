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
        int MaxValue = 0;
        int MinValue = 0;
        bool profitChecker = true;
        bool isFirstValue = true;
        List<int> lossList = new List<int>();

        profitChecker = CalculateMaximalLoss(n, inputs, isFirstValue, MaxValue, profitChecker, lossList);

        DisplayResult(profitChecker, lossList);
    }

    private static bool CalculateMaximalLoss(int n, string[] inputs, bool isFirstValue, int MaxValue, bool profitChecker,
        List<int> lossList)
    {
        int MinValue;
        for (int i = 0; i < n; i++)
        {
            int v = int.Parse(inputs[i]);

            if (isFirstValue == true)
            {
                MaxValue = v;
                isFirstValue = false;
            }
            else
            {
                if (v > MaxValue)
                {
                    if (i != n - 1)
                    {
                        MaxValue = v;
                    }
                }
                else if (v < MaxValue)
                {
                    MinValue = v;
                    profitChecker = false;
                    lossList.Add(MinValue - MaxValue);
                }
            }
        }

        return profitChecker;
    }

    private static void DisplayResult(bool profitChecker, List<int> lossList)
    {
        if (profitChecker == true)
        {
            Console.WriteLine($"0");
        }
        else
        {
            Console.WriteLine($"{lossList.Min()}");
        }
    }


    private static bool IsFirstValue(bool isFirstValue) => isFirstValue == true;
}