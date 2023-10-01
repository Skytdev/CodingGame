using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class PlaySpoon
{
    static void Spoon(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        var lineList = new List<string>();
        var nodeList = new List<Node>();

        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            lineList.Add(line);
            Console.Error.WriteLine(lineList[i]);
        }
        Console.Error.WriteLine("\n");

        for (int i = 0; i < height; i++)
        {
            AddNode(nodeList, lineList, height, width, i);
        }
        PrintNode(nodeList);

    }

    private static void PrintNode(List<Node> nodeList)
    {
        foreach (var node in nodeList)
        {
            Console.WriteLine($"{node.NodeX} {node.NodeY} " +
                              $"{node.RightNode.NodeX} {node.RightNode.NodeY} " +
                              $"{node.BotNode.NodeX} {node.BotNode.NodeY}");
        }
    }

    private static void AddNode(List<Node> nodeList, List<string> lineList, int height, int width, int currentLine)
    {
        for (int x = 0; x < width; x++)
        {
            if (IsNode(lineList, currentLine, x))
            {
                Console.Error.WriteLine($"Node found at ({x}, {currentLine}) !");
                var currentNode = new Node(x, currentLine);
                currentNode.RightNode = SearchNextNode(lineList, width, currentLine, x);
                currentNode.BotNode = SearchBottomNode(lineList, height, currentLine, x);
                nodeList.Add(currentNode);
            }
        }
    }

    private static Node SearchNextNode(List<string> lineList, int width, int currentLine, int x)
    {
        for (int xIndex = x + 1; xIndex < width; xIndex++)
        {
            if (IsNode(lineList, currentLine, xIndex))
            {
                Console.Error.WriteLine($"Next Node found at ({xIndex}, {currentLine}) !");
                return new Node(xIndex, currentLine);
            }
        }
        Console.Error.WriteLine($"Not Bottom Node found (-1, -1)");
        return new Node(-1 , -1);
    }

    private static Node SearchBottomNode(List<string> lineList, int height, int startLine, int x)
    {
        for (int yIndex = startLine + 1; yIndex < height; yIndex++)
        {
            if (IsNode(lineList, yIndex, x))
            {
                Console.Error.WriteLine($"Bottom Node found at ({x}, {yIndex}) !");
                return new Node(x, yIndex);
            }
        }
        Console.Error.WriteLine($"Not Bottom Node found (-1, -1)");
        return new Node(-1, -1);
    }

    private static bool IsNode(List<string> lineList, int yIndex, int x)
    {
        return lineList[yIndex][x] == '0';
    }


    public class Node
    {
        public int NodeX { get; set; }
        public int NodeY { get; set; }
        public Node RightNode { get; set; }
        public Node BotNode { get; set; }

        public Node(int nodeX, int nodeY)
        {
            NodeX = nodeX;
            NodeY = nodeY;
        }
    }
}