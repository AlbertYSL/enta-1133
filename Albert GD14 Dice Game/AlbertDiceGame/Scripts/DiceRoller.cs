using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class DiceRoller
    {
        public static void Dice()
        {
            Random rm = new Random();
            int d6 = rm.Next(1, 7);
            int d8 = rm.Next(1, 9);
            int d12 = rm.Next(1, 13);
            int d20 = rm.Next(1, 21);

            Console.WriteLine($"you got {d6}");
            Console.WriteLine($"you got {d8}");
            Console.WriteLine($"you got {d12}");
            Console.WriteLine($"you got {d20}");
            Console.WriteLine();
            Console.WriteLine("Max Roll:");
            Console.WriteLine($"{d6 + d8 + d12 + d20}");
        }
    }
}
