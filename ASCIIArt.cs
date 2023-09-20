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
public class Letters
{
    public string letter;
    public int[] code;
}

class Solution
{
    //                                    0      1      2         3        4      5       6      7
    public static string[] sequence = { "    ", "#   ", "##  ", "### ", " ## ", "  # ", " #  ", "# # " };
    public static IEnumerable<Letters> alphabet = new List<Letters> {
        new Letters { letter = "A", code = new int[] { 6, 7, 3, 7, 7 } },
        new Letters { letter = "B", code = new int[] { 2, 7, 2, 7, 2 } },
        new Letters { letter = "C", code = new int[] { 3, 1, 1, 1, 3 } },
        new Letters { letter = "D", code = new int[] { 2, 7, 7, 7, 2 } },
        new Letters { letter = "E", code = new int[] { 3, 1, 2, 1, 3 } },
        new Letters { letter = "F", code = new int[] { 3, 1, 2, 1, 1 } },
        new Letters { letter = "G", code = new int[] { 4, 1, 7, 7, 4 } },
        new Letters { letter = "H", code = new int[] { 7, 7, 3, 7, 7 } },
        new Letters { letter = "I", code = new int[] { 3, 6, 6, 6, 3 } },
        new Letters { letter = "J", code = new int[] { 4, 5, 5, 7, 6 } },
        new Letters { letter = "K", code = new int[] { 7, 7, 2, 7, 7 } },
        new Letters { letter = "L", code = new int[] { 1, 1, 1, 1, 3 } },
        new Letters { letter = "M", code = new int[] { 7, 3, 3, 7, 7 } },
        new Letters { letter = "N", code = new int[] { 3, 7, 7, 7, 7 } },
        new Letters { letter = "O", code = new int[] { 6, 7, 7, 7, 6 } },
        new Letters { letter = "P", code = new int[] { 2, 7, 2, 1, 1 } },
        new Letters { letter = "Q", code = new int[] { 6, 7, 7, 4, 5 } },
        new Letters { letter = "R", code = new int[] { 2, 7, 2, 7, 7 } },
        new Letters { letter = "S", code = new int[] { 4, 1, 6, 5, 2 } },
        new Letters { letter = "T", code = new int[] { 3, 6, 6, 6, 6 } },
        new Letters { letter = "U", code = new int[] { 7, 7, 7, 7, 3 } },
        new Letters { letter = "V", code = new int[] { 7, 7, 7, 7, 6 } },
        new Letters { letter = "W", code = new int[] { 7, 7, 3, 3, 7 } },
        new Letters { letter = "X", code = new int[] { 7, 7, 6, 7, 7 } },
        new Letters { letter = "Y", code = new int[] { 7, 7, 6, 6, 6 } },
        new Letters { letter = "Z", code = new int[] { 3, 5, 6, 1, 3 } },
        new Letters { letter = "?", code = new int[] { 3, 5, 4, 0, 6 } },
    };

    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        T = T.ToUpper();


        // splitString représente la chaine split : "M" "A" ....
        char[] splitString = T.Select(p => p).ToArray();


        // Boucle des lignes
        for (int i = 0; i < H; i++)
        {
            string toPrint = string.Empty;

            // Boucle du mot 
            var letterCount = splitString.Count();
            for (int f = 0; f < letterCount; f++)
            {

                var currentLetter = splitString[f];
                if (currentLetter >= 'A' && currentLetter <= 'Z')
                {
                    var matchingLetter = alphabet.First(p => p.letter == currentLetter.ToString());
                    var codeLetterArray = matchingLetter.code;
                    toPrint = toPrint + sequence[codeLetterArray[i]];
                }
                else
                {
                    var matchingLetter = alphabet.First(p => p.letter == "?");
                    var codeLetterArray = matchingLetter.code;
                    toPrint = toPrint + sequence[codeLetterArray[i]];
                }

            }
            Console.WriteLine($"{toPrint}");

            string ROW = Console.ReadLine();
            // Console.WriteLine($"{toPrint}");
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}