using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class DiceRoller
    {
        public static void Dice()
        {
            Random rm = new Random();
            string[] diceType = { "Dice 4", "Dice 6", "Dice 8", "Dice 12", "Dice 20" };
            string chosenDic = diceType[rm.Next(diceType.Length)];



            int d4 = rm.Next(1, 5);
            int d6 = rm.Next(1, 7);
            int d8 = rm.Next(1, 9);
            int d12 = rm.Next(1, 13);
            int d20 = rm.Next(1, 21);
            int[] diceResults = { d4, d6, d8, d12, d20 };
            int dc = diceResults[rm.Next(diceResults.Length)];

            string playerchoseDicMessage = "Now, please chose and type 1 to 5 the dice will be ramdomly given to you every round.";
            Console.WriteLine(playerchoseDicMessage);
            string userInput = "";
            while (true) ///if false will stay in the loop
            {
                string playerretypeMessage = "T Y P E 1, 2, 3, 4 or 5 @_@ ";
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput == "1")
                {
                    Console.WriteLine($"you got {chosenDic} ~~~");
                    break; /// noly when player type down 1 to 5, than they can continue. (break the loop)
                }
                else if (userInput == "2")
                {
                    Console.WriteLine($"you got {chosenDic} ~~~");
                    break;
                }
                else if (userInput == "3")
                {
                    Console.WriteLine($"you got {chosenDic} ~~~");
                    break;
                }
                else if (userInput == "4")
                {
                    Console.WriteLine($"you got {chosenDic} ~~~");
                    break;
                }
                else if (userInput == "5")
                {
                    Console.WriteLine($"you got {chosenDic} ~~~");
                    break;
                }
                else { Console.WriteLine("Please Choose Again"); } ///No break so will get back to the choosing part.
                Console.WriteLine();
                Console.WriteLine(playerretypeMessage);
            }

            //Console.WriteLine($"In d4 you got {d4}");
            //Console.WriteLine($"In d6 you got {d6}");
            //Console.WriteLine($"In d8 you got {d8}");
            //Console.WriteLine($"In d12 you got {d12}");
            //Console.WriteLine($"In d20 you got {d20}");
            //Console.WriteLine($"you got {chosenDic} ~~~ ");
            //Console.WriteLine();
            if (chosenDic == "Dice 4")
            {
                Console.WriteLine($"{d4} Points");
            }
            else if (chosenDic == "Dice 6")
            {
                Console.WriteLine($"{d6} Points");
            }
            else if (chosenDic == "Dice 8")
            {
                Console.WriteLine($"{d8} Points");
            }
            else if (chosenDic == "Dice 12")
            {
                Console.WriteLine($"{d12} Points");
            }
            else if (chosenDic == "Dice 20")
            {
                Console.WriteLine($"{d20} Points");
            }

            //Console.WriteLine("total you got:");
            //Console.WriteLine($"{d4 + d6 + d8 + d12 + d20}");
        }
    }
}
