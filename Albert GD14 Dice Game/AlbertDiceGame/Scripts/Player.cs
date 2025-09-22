using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class Player
    {
        public static void Playerone()
        {
            Console.WriteLine("Would you like to play?");

            bool Yes = true;

            if (Yes) 
            {
                Console.WriteLine("Let go !!");
            }
            else
            {
                Console.WriteLine("Okey, goodbye.");
            }

            Console.WriteLine();
            string askenameMessge = "What is your name";
            Console.WriteLine(askenameMessge);

            Console.WriteLine();
            Console.WriteLine("Want to give a try?");
            Console.WriteLine();

            bool Start = true;
            bool Bye = false;

            if (Start)
            {
                Console.WriteLine("Start the Game Rules.");
            }
            else if (Bye) 
            {
                Console.WriteLine("Bye, see you");
            }
            else
            {
                Console.WriteLine("Ha, Too late ~ Let start from game rules.");
            }


            Console.WriteLine();
            DiceRoller roller = new DiceRoller();
            //Console.WriteLine("New DiceRoller");
            DiceRoller.Dice();
        }
    }
}
