using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print thorTX and thorTY, if Thor seems not follow your orders.
 **/
class Thor
{
    static void ThorStart(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int thorX = int.Parse(inputs[2]); // Thor's starting X position
        int thorY = int.Parse(inputs[3]); // Thor's starting Y position

        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...")

            Console.Error.WriteLine($"thor {thorX}, {thorY}");

            if (thorX > lightX && thorY < lightY)
            {
                Console.WriteLine("SW");
                thorX--;
                thorY++;
            }
            else if (thorY < lightY && thorX < lightX)
            {
                Console.WriteLine("SE");
                thorY++;
                thorX++;
            }
            else if (thorX < lightX && thorY > lightY)
            {
                Console.WriteLine("NE");
                thorY--;
                thorX++;
            }
            else if (thorY > lightY && thorX > lightX)
            {
                Console.WriteLine("NW");
                thorX--;
                thorY--;
            }
            else if (thorX < lightX)
            {
                Console.WriteLine("E");
                thorX++;
                // Si l'éclair est au W
            }
            else if (thorX > lightX)
            {
                Console.WriteLine("W");
                thorX--;
                // Si l'éclair est au S
            }
            else if (thorY < lightY)
            {
                Console.WriteLine("S");
                thorY++;
                // Si l'éclair est au N
            }
            else if (thorY > lightY)
            {
                Console.WriteLine("N");
                thorY--;
            }


            // A single line providing the move to be made: N NE E SE S SW W or NW
        }
    }
}