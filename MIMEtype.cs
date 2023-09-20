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
    public class Dico
    {
        public int id { get; set; }
        public string ext { get; set; }
        public string name { get; set; }
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        string[] inputs;
        string FNAME;
        var library = new List<Dico>();

        for (int i = 0; i < N; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            library.Add(new Dico()
            {
                id = i,
                ext = inputs[0].ToLower(),
                name = inputs[1]
            });
            string EXT = inputs[0]; // file extension
            string MT = inputs[1]; // MIME type.
            // Console.Error.WriteLine($"Loop {i} / EXT = {inputs[0]} / MT = {inputs[1]}");
        }
        Console.Error.WriteLine($"---------- DICO ----------");
        foreach (var item in library)
        {
            Console.Error.WriteLine($"id = {item.id} | ext = {item.ext} | name = {item.name}");
        }
        Console.Error.WriteLine($"\n");

        Console.Error.WriteLine($"---------- INPUTS ----------");
        for (int i = 0; i < Q; i++)
        {
            string isInDico = null;
            FNAME = Console.ReadLine(); // One file name per line.
            FNAME = FNAME.ToLower();
            Console.Error.WriteLine($"LE NOM DU FICHIER = {FNAME}");

            var extToCheck = FNAME.Split('.').Last();
            Console.Error.WriteLine($"LA PARTIE RECUPEREE ET TESTEE = {extToCheck}");

            var isValid = FNAME.Contains('.');

            var exist = library.Any(p => p.ext == extToCheck);
            Console.Error.WriteLine($"LA PARTIE RECUPEREE EXISTE DANS LA LIBRAIRIE = {exist}");

            if (exist)
            {
                isInDico = library.FirstOrDefault(p => p.ext == extToCheck).name;
            }

            if (exist && isValid)
            {
                Console.WriteLine($"{isInDico}");
            }
            else
            {
                Console.WriteLine("UNKNOWN");
            }
            Console.Error.WriteLine($"\n");
        }

        // Write an answer using Console.WriteLine()
        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
    }
}