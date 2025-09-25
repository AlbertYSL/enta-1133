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
            DiceRoller roller = new DiceRoller();
            ///Asking what's the player name, read the playername by userInput.
            string askenameMessge = "What is your name";
            Console.WriteLine(askenameMessge);
            string playerName = Console.ReadLine();

            Console.WriteLine("Starting the Rules of the Game.");
            string pressenterMessage = ("Please press Enter to continue.");
            Console.WriteLine(pressenterMessage);
            //Contiue to next event by pressing Space.
            string userInput = Console.ReadLine();
           if (userInput == "Enter")
            {
                Console.WriteLine("Both players get five differnet dices (d6, d6, d8, d12, d20)");
                Console.WriteLine("Then, randomly shoode one die.");
                Console.WriteLine("After players have chosen, roll the dice.");
                Console.WriteLine("Recore both plays' scores.");
                Console.WriteLine("Continue 8 rounds.");
                Console.WriteLine("At the end who got the most points win.");
            }
            else
            {
                Console.WriteLine("Both players get five differnet dices (d6, d6, d8, d12, d20)");
                Console.WriteLine("Then, randomly shoode one die.");
                Console.WriteLine("After players have chosen, roll the dice.");
                Console.WriteLine("Recore both plays' scores.");
                Console.WriteLine("Continue 8 rounds.");
                Console.WriteLine("At the end who got the most points win.");
            }

            Console.WriteLine();
            /// Read the PlayerName
            Console.WriteLine($"Now,{playerName} Would you like to play?? ");
            Console.WriteLine("Yes = 1, No = 2");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Let go !!");
                Console.WriteLine();
                DiceRoller.Dice();
            }
            else
            {
                Console.WriteLine("Too late ~ ~ Still need to play ^_^ ");
                Console.WriteLine();
                DiceRoller.Dice();
            }            


            Console.WriteLine();
            //DiceRoller roller = new DiceRoller();
            //Console.WriteLine("New DiceRoller");
            //DiceRoller.Dice();
        }
    }
}
