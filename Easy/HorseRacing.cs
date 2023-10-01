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
class HorseRacing
{
    static void HorseStart(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> ecartArray = new List<int>();
        Console.Error.WriteLine($"NbChevaux - {N}");


        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            ecartArray.Add(pi);
            // Console.Error.WriteLine($"ARRAY = {ecartArray[i]}");
        }

        ecartArray.Sort();
        DisplayArray(ecartArray);

        var answer = GetGap(ecartArray).Min();
        DisplayArray(GetGap(ecartArray));

        Console.WriteLine($"{answer}");
    }

    public static void DisplayArray(List<int> Array)
    {
        Console.Error.WriteLine($"------- START ARRAY -------");
        foreach (var item in Array)
        {
            Console.Error.WriteLine($"{item}");
        }
        Console.Error.WriteLine($"------- END -------");

    }

    public static List<int> GetGap(List<int> horseList)
    {
        var result = new List<int>();

        for (int i = 0; i < (horseList.Count() - 1); i++)
        {
            var gap = (horseList[i] - horseList[i + 1]);
            Console.Error.WriteLine($"index - {i} / gap - {gap}");

            result.Add(Math.Abs(gap));
        }

        return result;
    }
}