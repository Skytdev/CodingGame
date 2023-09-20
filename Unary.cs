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
        string MESSAGE = Console.ReadLine();
        Console.WriteLine(MESSAGE);


        var byteArray = Encoding.ASCII.GetBytes(MESSAGE);
        var combined = string.Empty;
        var combinedUnary = string.Empty;

        foreach (var letter in byteArray)
        {
            var letterInBinary = ToBinary(letter);
            combined += letterInBinary;
        }
        Console.Error.WriteLine($"combined : {combined}");

        combinedUnary = ToUnary(combined);
        // for (var i = 0; i < toBinaryMessage.Length; i++) 
        // {
        //     Console.Error.WriteLine($"length[{i}] = {toBinaryMessage[i]}");
        // }
        // Console.Error.WriteLine($"message = {MESSAGE}");

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(combinedUnary);
    }

    public static string ToBinary(int input)
    {

        // Console.Error.WriteLine($"{input}");
        var binary = string.Empty;

        while (input > 0)
        {
            var number = input / 2;
            var remain = input % 2;
            binary = remain.ToString() + binary;
            input = number;
        }
        // Console.Error.WriteLine(binary);
        return binary;
    }

    public static string ToUnary(string stringToCheck)
    {
        var unaryString = string.Empty;
        var combinedLength = stringToCheck.Length;
        var i = 0;

        while (i < combinedLength)
        {
            if (stringToCheck[i] == '1')
            {
                unaryString += "0 0";
                Console.Error.WriteLine($"Mon char actuel est 1 /  index {i}");
                i++;

                while (stringToCheck[i] == '1')
                {
                    Console.Error.WriteLine($"Tant que le prochain char est 1 /  index {i}");
                    unaryString += "0";
                    if (i + 1 < combinedLength && stringToCheck[i + 1] == stringToCheck[i])
                    {
                        Console.Error.WriteLine($"Si le prochain char n'est pas nul et le prochain char est le même /  index {i}");
                        i++;
                    }
                    else
                    {
                        i++;
                        Console.Error.WriteLine($"Le prochain est zéro /  index {i}\n");
                        break;
                    }
                }
                if (i + 1 < combinedLength)
                {
                    unaryString += " ";
                }
            }
            else
            {
                unaryString += "00 0";
                Console.Error.WriteLine($"Mon char actuel est 0 /  index {i}");
                i++;

                while (stringToCheck[i] == '0')
                {
                    Console.Error.WriteLine($"Tant que le prochain char est 0 /  index {i}");
                    unaryString += "0";
                    if (i + 1 < combinedLength && stringToCheck[i + 1] == stringToCheck[i])
                    {
                        Console.Error.WriteLine($"Si le prochain char n'est pas nul et le prochain char est le même /  index {i}");
                        i++;
                    }
                    else
                    {
                        Console.Error.WriteLine($"Le prochain est un /  index {i}\n");
                        i++;
                        break;
                    }
                }
                if (i + 1 < combinedLength)
                {
                    unaryString += " ";
                }
            }
        }

        return unaryString;
    }

}