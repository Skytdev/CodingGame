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
class Shadow
{
    static void ShadowStart(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);

        var position = new Position(X0, Y0, W, H);

        // game loop
        while (true)
        {
            string signal = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            Console.Error.WriteLine($"SIGNAL = {signal}");
            Console.Error.WriteLine($"POSITIONS = {position.posX} {position.posY}");

            var newPos = Search(position, signal);
            position = newPos;
            string result = $"{newPos.posX} {newPos.posY}";

            Console.WriteLine($"{result}");
        }
    }

    public static Position Search(Position position, string signal)
    {
        Console.Error.WriteLine($"XPOS = {position.posX} / YPOS = {position.posY} / height = {position.gridHeight}");

        var posX = position.posX;
        var posY = position.posY;
        var width = position.gridWidth;
        var height = position.gridHeight;


        if (signal.Contains("DL"))
        {
            // newPos[0] = position[0] + 1;
            // newPos[1] = position[1] + 1;
        }
        else if (signal.Contains("DR"))
        {
            // newPos[0] = position[0] + 1;
            // newPos[1] = position[1] + 1;
        }
        else if (signal.Contains("UL"))
        {
            // newPos[0] = position[0] - 1;
            // newPos[1] = position[1] - 1;
        }
        else if (signal.Contains("UR"))
        {
            // newPos[0] = position[0] + 1;
            // newPos[1] = position[1] - 1;
        }
        if (signal.Contains("L"))
        {
            // newPos[0] = position[0] - 1;
        }
        else if (signal.Contains("R"))
        {
            // newPos[0] = position[0] + 1;
        }
        else if (signal.Contains("D"))
        {
            // newPos[1] = gridWidth / 2;
            Console.Error.WriteLine($"posY = {posY} + (({height} - {posY}) / 2");
            posY = posY + (height / 2);
            Console.Error.WriteLine($"height = {height} - {posY}");
            height = height - posY;
        }
        else if (signal.Contains("U"))
        {
            // newPos[1] = position[1] - 1;
            Console.Error.WriteLine($"posY = {posY} - (({height} / 2");
            posY = posY - (height / 2);
            Console.Error.WriteLine($"height = {posY}");
            height = posY;
        }

        var newPosition = new Position(
            posX,
            posY,
            width,
            height
        );

        return newPosition;
    }

    public class Position
    {
        public int posX { get; }
        public int posY { get; }
        public int gridWidth { get; }
        public int gridHeight { get; }

        public Position(int x, int y, int width, int height)
        {
            posX = x;
            posY = y;
            gridWidth = width;
            gridHeight = height;
        }
    }
}