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
class LogicGates
{
    static void LogicStart(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        var signalList = new List<Inputs>();

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            var inputName = inputs[0];
            signalList.Add(new Inputs(
                inputs[0],
                inputs[1]
            ));
            Console.Error.WriteLine($"{inputs[0]} {inputs[1]}");
        }


        for (int i = 0; i < m; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string outputName = inputs[0];
            string type = inputs[1];
            string inputName1 = inputs[2];
            string inputName2 = inputs[3];
            Console.Error.WriteLine($"{outputName} {type} {inputName1} {inputName2}\n");
            var firstStringToMatch = signalList.FirstOrDefault(p => p.Name == inputName1).Format;
            var secondStringToMatch = signalList.FirstOrDefault(p => p.Name == inputName2).Format;

            var result = (GetNewForm(type, firstStringToMatch, secondStringToMatch));
            Console.WriteLine($"{outputName} {result}");
        }

    }

    public static string GetNewForm(string type, string firstStringToMatch, string secondStringToMatch)
    {
        var result = "";
        var firstSignal = firstStringToMatch;
        var secondSignal = secondStringToMatch;

        // Console.Error.WriteLine($"type : {type} / signal {signal[0]} {signal[1]}");

        if (type == "AND")
        {
            result = GetAND(firstSignal, secondSignal);
        }
        else if (type == "OR")
        {
            result = GetOR(firstSignal, secondSignal);

        }
        else if (type == "XOR")
        {
            result = GetXOR(firstSignal, secondSignal);
        }
        else if (type == "NAND")
        {
            result = GetNAND(firstSignal, secondSignal);
        }
        else if (type == "NOR")
        {
            result = GetNOR(firstSignal, secondSignal);
        }
        else if (type == "NXOR")
        {
            result = GetNXOR(firstSignal, secondSignal);
        }
        return result;
    }

    public static string GetAND(string firstSignal, string secondSignal)
    {

        var result = "";

        for (int i = 0; i < firstSignal.Count(); i++)
        {
            if (firstSignal[i] != secondSignal[i])
            {
                result = result + "_";
            }
            else
            {
                result = result + firstSignal[i];
            }

        }
        return result;
    }

    public static string GetNAND(string firstSignal, string secondSignal)
    {

        var result = "";

        for (int i = 0; i < firstSignal.Count(); i++)
        {
            char _true = '-';
            char _false = '_';
            if (firstSignal[i] == _false || secondSignal[i] == _false)
            {
                result = result + _true;
            }
            else
            {
                result = result + _false;
            }

        }
        return result;
    }

    public static string GetOR(string firstSignal, string secondSignal)
    {

        var result = "";

        for (int i = 0; i < firstSignal.Count(); i++)
        {
            char _true = '-';
            char _false = '_';

            if (firstSignal[i] == _true || secondSignal[i] == _true)
            {
                result = result + _true;
            }
            else
            {
                result = result + _false;
            }
        }
        return result;
    }

    public static string GetXOR(string firstSignal, string secondSignal)
    {

        var result = "";
        for (int i = 0; i < firstSignal.Count(); i++)
        {
            char _true = '-';
            char _false = '_';

            if (firstSignal[i] != secondSignal[i])
            {
                result = result + _true;
            }
            else
            {
                result = result + _false;
            }
        }
        return result;
    }

    public static string GetNOR(string firstSignal, string secondSignal)
    {

        var result = "";
        for (int i = 0; i < firstSignal.Count(); i++)
        {
            char _true = '-';
            char _false = '_';

            if (firstSignal[i] == _true || secondSignal[i] == _true)
            {
                result = result + _false;
            }
            else
            {
                result = result + _true;
            }
        }
        return result;
    }

    public static string GetNXOR(string firstSignal, string secondSignal)
    {

        var result = "";
        for (int i = 0; i < firstSignal.Count(); i++)
        {
            char _true = '-';
            char _false = '_';

            if (firstSignal[i] == secondSignal[i])
            {
                result = result + _true;
            }
            else
            {
                result = result + _false;
            }
        }
        return result;
    }

    public class Inputs
    {
        public string Name { get; }
        public string Format { get; }

        public Inputs(string name, string format)
        {
            Name = name;
            Format = format;
        }
    }

}