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
class Prout
{
    public static void PrintAlphabet(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        var result = string.Empty;
        
        for (char c = 'A'; c < ('A' + n); c++)
        {
            result = result + (char)(65 + ((65 + c) % 26));

            Console.WriteLine($"{result}");
        }


    }
}