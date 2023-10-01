using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        Console.Error.WriteLine($"Number of Nodes = {N}");
        Console.Error.WriteLine($"Number of Links = {L}");
        Console.Error.WriteLine($"Number of Gateways = {E}\n");
        List<Node> Nodes = new List<Node>();


        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            Console.Error.WriteLine($"link between the nodes indexed N1 = {N1}");
            Console.Error.WriteLine($"link between the nodes indexed N2 = {N2}\n");
            Nodes.Add(new Node(
                N1,
                N2
            ));
        }

        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            Console.Error.WriteLine($"Index of Gateways = {EI}\n");

        }


        while (true)
        {
            int SI = int.Parse(Console
                .ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
            Console.Error.WriteLine($"VIRUS MOVE = {SI}\n");
        }
    }

    public class Node
    {
        public int N1 { get; set; }
        public int N2 { get; set; }

        public Node(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
        }
    }
}