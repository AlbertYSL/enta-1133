using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
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
            string[] diceTypes = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };/// Letting the code know that diceTypes [] = {Dice4 to Dice20}
            string chosenDice = diceTypes[rm.Next(diceTypes.Length)];///using Length without -1 is because dont need max. By Random diceTypes.



            int d4 = rm.Next(1, 5);
            int d6 = rm.Next(1, 7);
            int d8 = rm.Next(1, 9);
            int d12 = rm.Next(1, 13);
            int d20 = rm.Next(1, 21);
            int[] diceResults = { d4, d6, d8, d12, d20 }; /// Letting the code know that diceResults [] = {d4 to d20}
            int dc = diceResults[rm.Next(diceResults.Length)]; ///using Length without -1 is because dont need max. By Random dicResults.
            int playerresult = 0;
            int computerresult = 0;
            int playerscore = 0;
            int computerscore = 0;

            string playerchoseDicMessage = "Now, please chose and type 1 to 5 the dice will be ramdomly given to you every round.";
            Console.WriteLine(playerchoseDicMessage);
            string userInput = ""; 
            while (true) ///if false will stay in the loop
            {
                string playerretypeMessage = "T Y P E 1, 2, 3, 4 or 5 @_@ ";
                userInput = Console.ReadLine(); /// player can type (userInput)  by using Console (show when code is running) ReadLine (place to type, ReadLine for Read).
                Console.WriteLine();

                if (userInput == "1") /// if player type 1, this code will open and show "you got {the random dice you get (Dice4 to Dice20) } ~~~".
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break; /// only when player type down 1 to 5, than they can continue. (break the loop)
                }
                else if (userInput == "2")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "3")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "4")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "5")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else { Console.WriteLine("Please Choose Again"); } ///No break so will get back to the choosing part.
                Console.WriteLine();
                Console.WriteLine(playerretypeMessage);
            }

            //int playerValue = RollDie(rm,chosenDic);

            //Console.WriteLine($"In d4 you got {d4}");
            //Console.WriteLine($"In d6 you got {d6}");
            //Console.WriteLine($"In d8 you got {d8}");
            //Console.WriteLine($"In d12 you got {d12}");
            //Console.WriteLine($"In d20 you got {d20}");
            //Console.WriteLine($"you got {chosenDic} ~~~ ");
            Console.WriteLine();
            if (chosenDice == "Dice4") ///when Dice4 jump out, the player can know the points they got.
            {
                Console.WriteLine($"{d4} Points");
                playerresult = d4;
            }
            else if (chosenDice == "Dice6")
            {
                Console.WriteLine($"{d6} Points");
                playerresult = d6;
            }
            else if (chosenDice == "Dice8")
            {
                Console.WriteLine($"{d8} Points");
                playerresult = d8;
            }
            else if (chosenDice == "Dice12")
            {
                Console.WriteLine($"{d12} Points");
                playerresult = d12;
            }
            else if (chosenDice == "Dice20")
            {
                Console.WriteLine($"{d20} Points");
                playerresult = d20;
            }

            Console.WriteLine();
            string[] diceType = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            string chosenDic = diceType[rm.Next(diceType.Length)];

            if (chosenDic == "Dice4")
            {
                Console.WriteLine();
                Console.WriteLine("CPU choose Dice4");
                Console.WriteLine($"Got {d4} points");
                computerresult = d4;
            }
            else if (chosenDic == "Dice6")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice6");
                Console.WriteLine($"Got {d6} points");
                computerresult = d6;
            }
            else if (chosenDic == "Dice8")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice8");
                Console.WriteLine($"Got {d8} points");
                computerresult = d8;
            }
            else if (chosenDic == "Dice12")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice12");
                Console.WriteLine($"Got {d12} points");
                computerresult = d12;
            }
            else if (chosenDic == "Dice20")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice20");
                Console.WriteLine($"Got {d20} points");
                computerresult = d20;
            }


            //Console.WriteLine("total you got:");
            //Console.WriteLine($"{d4 + d6 + d8 + d12 + d20}");
            Console.WriteLine();
            if (computerresult > playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("You lose at CPU this round ~~ +_+");
                computerscore = +1;
            }
            else if (computerresult < playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("You WIN this round!!");
                playerscore = +1;
            }
            else if (computerresult == playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("It's a tie =.=");
                playerscore = +1;
                computerscore = +1;
            }

            Console.WriteLine() ;
            Console.WriteLine(" Player: " + playerscore + " " + "----" + " " + "computer: " + computerscore) ;
        }
        public static void ComputerTurn()
        {
            Random rand = new Random();
            int d4 = rand.Next(1, 5);
            int d6 = rand.Next(1, 7);
            int d8 = rand.Next(1, 9);
            int d12 = rand.Next(1, 13);
            int d20 = rand.Next(1, 21);
            int playerresult = 0;
            int computerresult = 0;
            int playerscore = 0;
            int computerscore = 0;
            string[] diceType = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            string chosenDic = diceType[rand.Next(diceType.Length)];

            if (chosenDic == "Dice4")
            {
                Console.WriteLine();
                Console.WriteLine("CPU choose Dice4");
                Console.WriteLine($"Got {d4} points");
                computerresult = d4;
            }
            else if (chosenDic == "Dice6")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice6");
                Console.WriteLine($"Got {d6} points");
                computerresult = d6;
            }
            else if (chosenDic == "Dice8")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice8");
                Console.WriteLine($"Got {d8} points");
                computerresult = d8;
            }
            else if (chosenDic == "Dice12")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice12");
                Console.WriteLine($"Got {d12} points");
                computerresult = d12;
            }
            else if (chosenDic == "Dice20")
            {
                Console.WriteLine();
                Console.WriteLine($"CPU choose Dice20");
                Console.WriteLine($"Got {d20} points");
                computerresult = d20;
            }

            Console.WriteLine();

            string[] diceTypes = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            string chosenDice = diceTypes[rand.Next(diceType.Length)];
            string playerchoseDicMessage = "Now, please chose and type 1 to 5.";
            Console.WriteLine(playerchoseDicMessage);
            string userInput = "";
            while (true)
            {
                string playerretypeMessage = "T Y P E 1, 2, 3, 4 or 5 @_@ ";
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput == "1")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "2")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "3")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "4")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else if (userInput == "5")
                {
                    Console.WriteLine($"you got {chosenDice} ~~~");
                    break;
                }
                else { Console.WriteLine("Please Choose Again"); }
                Console.WriteLine();
                Console.WriteLine(playerretypeMessage);

            }

            Console.WriteLine();
            if (chosenDice == "Dice4")
            {
                Console.WriteLine($"{d4} Points");
                playerresult = d4;
            }
            else if (chosenDice == "Dice6")
            {
                Console.WriteLine($"{d6} Points");
                playerresult = d6;
            }
            else if (chosenDice == "Dice8")
            {
                Console.WriteLine($"{d8} Points");
                playerresult = d8;
            }
            else if (chosenDice == "Dice12")
            {
                Console.WriteLine($"{d12} Points");
                playerresult = d12;
            }
            else if (chosenDice == "Dice20")
            {
                Console.WriteLine($"{d20} Points");
                playerresult = d20;
            }

            Console.WriteLine();
            
            if (computerresult > playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("You lose at CPU this round ~~ +_+");
                computerscore = +1;
            }
            else if (computerresult < playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("You WIN this round!!");
                playerscore = +1;
            }
            else if (computerresult == playerresult)
            {
                Console.WriteLine();
                Console.WriteLine("It's a tie =.=");
                playerscore = +1;
                computerscore = +1;
            }

            Console.WriteLine();
            Console.WriteLine(" Player: " + playerscore + " " + "----" + " " + "computer: " + computerscore);
        }
    }
}
