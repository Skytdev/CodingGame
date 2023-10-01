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
class Death
{
    static void MainDeath(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        List<GatewayNode> nodes = new List<GatewayNode>();
        List<Gateway> gateways = new List<Gateway>();

        AddNodes(L, nodes);
        AddGateway(E, gateways);
        nodes = KeepOnlyGatewayNodes(nodes, gateways);

        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
            SecureLink(nodes, SI);
        }
    }

    private static void SecureLink(List<GatewayNode> nodes, int SI)
    {
        if (NodeContainVirus(nodes, SI))
        {
            var node = nodes.First(p => p.N1 == SI || p.N2 == SI);
            Console.WriteLine($"{node.N1} {node.N2}");
            nodes.RemoveAt(nodes.FindIndex(p => p.N1 == SI || p.N2 == SI));
        }
        else
        {
            var node = nodes.First();
            Console.WriteLine($"{node.N1} {node.N2}");
        }
    }

    private static bool NodeContainVirus(List<GatewayNode> nodes, int SI)
    {
        return nodes.Any(p => p.N1 == SI || p.N2 == SI);
    }


    private static List<GatewayNode> KeepOnlyGatewayNodes(List<GatewayNode> nodes, List<Gateway> gateways)
    {
        var newList = new List<GatewayNode>();
        foreach (var node in nodes)
        {
            if (gateways.Any(p => p.Index == node.N1) || gateways.Any(p => p.Index == node.N2))
            {
                newList.Add(node);
            }
        }
        return newList;
    }

    private static void AddNodes(int L, List<GatewayNode> Nodes)
    {
        string[] inputs;
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            Nodes.Add(new GatewayNode(
                N1,
                N2
            ));
        }
    }

    private static void AddGateway(int E, List<Gateway> gateways)
    {
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gateways.Add(new Gateway(EI));
        }
    }

    public class GatewayNode
    {
        public int N1 { get; set; }
        public int N2 { get; set; }

        public GatewayNode(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
        }
    }

    public class Gateway
    {
        public int Index { get; }

        public Gateway(int index)
        {
            Index = index;
        }
    }
}