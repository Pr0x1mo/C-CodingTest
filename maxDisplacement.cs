using System;
using System.IO;
using System.Linq;

public class HelloWorld
{
    static public void Main()
    {
        String Str = Console.ReadLine();
        int N = Convert.ToInt32(Console.ReadLine());

        int out_ = Game(Str, N);
        Console.Out.WriteLine(out_);
    }

    static int Game(String Str, int N)
    {
        int currentDisplacement = 0;
        int totalS = 0;
        int totalR = 0;

        // Calculate initial displacement and count of S and R
        foreach (char command in Str)
        {
            if (command == 'S')
            {
                currentDisplacement++;
                totalS++;
            }
            else if (command == 'R')
            {
                currentDisplacement--;
                totalR++;
            }
        }

        // Calculate maximum displacement
        // Try to maximize forward steps (S) and minimize backward steps (R)
        if (N <= totalR)
        {
            return currentDisplacement + 2 * N;  // Convert R to S
        }
        else
        {
            int remainingChanges = N - totalR;
            if (remainingChanges <= totalS)
            {
                return currentDisplacement + 2 * totalR + 2 * remainingChanges;  // Convert all R to S and some S to R
            }
            else
            {
                return totalS + totalR;  // All commands can be made to S theoretically for maximum forward displacement
            }
        }
    }
}
