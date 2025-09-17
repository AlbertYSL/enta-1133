using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class DiceRoller
    {
        int numberOfSides = 6;

        public void Description()
        {
            Console.WriteLine("Rolls a six sided dice.");
            Console.WriteLine("Min Roll:");
            Console.WriteLine(1);
            Console.WriteLine("Max Roll:");
            Console.WriteLine(numberOfSides);
        }
    }
}
