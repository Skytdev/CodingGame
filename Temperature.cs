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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse

        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        string[] inputs = Console.ReadLine().Split(' ');
        int nearz = int.Parse(inputs[0]);

        for (int i = 1; i < n; i++)
        {

            int b = int.Parse(inputs[i]);    // a temperature expressed as an integer ranging from -273 to 5526

            Console.Error.WriteLine($"nearz = {nearz}, b = {b}");

            if (Math.Abs(nearz) > Math.Abs(b))
            {
                nearz = b;
            }
            else if (Math.Abs(nearz) == Math.Abs(b))
            {
                nearz = Math.Abs(b);
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(nearz);
    }
}