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

        private List<string> bag = new List<string>();

        public void AddItem(string name)
        {
            bag.Add(name);
            Console.WriteLine($" you got {name}");
        }

        public void Print()
        {
            Console.WriteLine("your bag: ");
            if (bag.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }
            for (int i = 0; i < bag.Count; i++)
            {
                Console.WriteLine($"[{i}] {bag[i]}");
            }
            Console.WriteLine($" Item number: {bag.Count}");
        }
        public void PlayerOne()
        {
            Random rm = new Random();
            int playerresult = 0;
            int computerresult = 0;
            int playerscore = 0;
            int computerscore = 0;

            /// Let the code know what dice and how many dice by make a new list <string / int>, give the dice name and sides for the player. 
            List<string> diceName = new List<string> { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            List<int> diceSide = new List<int> { 4, 6, 8, 12, 20 };

            ///Let the code know what dice and how many dice bt make a new liset <string / int> </string>, give the dice name and sides for the CPU
            List<string> cpuDiceName = new List<string> { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            List<int> cpuDiceSide = new List<int> { 4, 6, 8, 12, 20 };

            ///put at here so it can be accumulation.
            int totalRounds = diceName.Count;
            ///set the rounds end when all of the dice been used.

            string[] diceTypes = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };/// Letting the code know that diceTypes [] = {Dice4 to Dice20}

            for (int round = 1; round <= totalRounds; round++)
            {
                System.Threading.Thread.Sleep(2000); ///Stop for 2 sec to wait the result.

                int prindex = rm.Next(diceSide.Count);
                int sides = diceSide[prindex];
                /// randomly chosen dice from index and knowing the dice and sides from it. --- by seeing the "List" up there.


                Console.WriteLine($"\n===== Round {round}/{totalRounds} =====");
                /// by using \n so it'll shows the countinue of the lines.
                string chosenDice = diceName[prindex];


                int d4 = rm.Next(1, 5);
                int d6 = rm.Next(1, 7);
                int d8 = rm.Next(1, 9);
                int d12 = rm.Next(1, 13);
                int d20 = rm.Next(1, 21);
                int[] diceResults = { d4, d6, d8, d12, d20 }; /// Letting the code know that diceResults [] = {d4 to d20}
                int dc = diceResults[rm.Next(diceResults.Length)]; ///using Length without -1 is because dont need max. By Random dicResults.

                string playerchoseDicMessage = "Chose your fate by type 1 to 5.";
                Console.WriteLine(playerchoseDicMessage);
                string userInput = "";
                while (true) ///if false will stay in the loop
                {
                    string playerretypeMessage = " > T Y P E 1, 2, 3, 4 or 5 @_@ ";
                    userInput = Console.ReadLine(); /// player can type (userInput)  by using Console (show when code is running) ReadLine (place to type, ReadLine for Read).
                    Console.WriteLine();

                    if (userInput == "1") /// if player type 1, this code will open and show "you got {the random dice you get (Dice4 to Dice20) } ~~~".
                    {
                        Console.WriteLine($"> You got {chosenDice} ~~~");
                        break; /// only when player type down 1 to 5, than they can continue. (break the loop)
                    }
                    else if (userInput == "2")
                    {
                        Console.WriteLine($"> You got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "3")
                    {
                        Console.WriteLine($"> You got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "4")
                    {
                        Console.WriteLine($"> You got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "5")
                    {
                        Console.WriteLine($"> You got {chosenDice} ~~~");
                        break;
                    }
                    else { Console.WriteLine(" > Please Choose Again <"); } ///No break so will get back to the choosing part.
                    Console.WriteLine();
                    Console.WriteLine(playerretypeMessage);
                }

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
                int cpuindex = rm.Next(cpuDiceName.Count);
                string[] diceType = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
                string chosenDic = cpuDiceName[cpuindex];
                int cpuSide = cpuDiceSide[cpuindex];

                if (chosenDic == "Dice4")
                {
                    Console.WriteLine();
                    Console.WriteLine("-- CPU got Dice4");
                    Console.WriteLine($" {d4} points");
                    computerresult = d4;
                }
                else if (chosenDic == "Dice6")
                {
                    Console.WriteLine();
                    Console.WriteLine($"-- CPU got Dice6");
                    Console.WriteLine($" {d6} points");
                    computerresult = d6;
                }
                else if (chosenDic == "Dice8")
                {
                    Console.WriteLine();
                    Console.WriteLine($"-- CPU got Dice8");
                    Console.WriteLine($" {d8} points");
                    computerresult = d8;
                }
                else if (chosenDic == "Dice12")
                {
                    Console.WriteLine();
                    Console.WriteLine($"-- CPU got Dice12");
                    Console.WriteLine($" {d12} points");
                    computerresult = d12;
                }
                else if (chosenDic == "Dice20")
                {
                    Console.WriteLine();
                    Console.WriteLine($"-- CPU got Dice20");
                    Console.WriteLine($" {d20} points");
                    computerresult = d20;
                }


                Console.WriteLine();
                if (computerresult > playerresult)
                {
                    Console.WriteLine();
                    Console.WriteLine(" >>>> " + "You lose at CPU this round ~~ +_+" + " <<<< ");
                    computerscore += 1;
                }
                else if (computerresult < playerresult)
                {
                    Console.WriteLine();
                    Console.WriteLine(" >>>> " + "You WIN this round!!" + " <<<< ");
                    playerscore += 1;
                }
                else if (computerresult == playerresult)
                {
                    Console.WriteLine();
                    Console.WriteLine(" >>>> " + "It's a tie =.=" + " <<<< ");
                    playerscore += 1;
                    computerscore += 1;
                }
                Console.WriteLine() ;

                ///removed the dice that had been used. removed both dice and sides from the index.
                diceName.RemoveAt(prindex);
                diceSide.RemoveAt(prindex);

                if (diceName.Count > 0)
                ///check if there still got any dice, if < 0 than it'll stop.
                {
                    System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                    Console.WriteLine(" >> Your remain FATE :");
                    Console.WriteLine();
                    ///let the player know if there Stll Got dice or not.
                    for (int i = 0; i < diceName.Count; i++)
                    /// use a loop to print the dice. (i == 0) the first dice, when ++ than (i == 1) the scond dice.
                    {
                        if (i == 0)
                        ///print the dice name.
                        {
                            Console.WriteLine(" >>> " + diceName [i] + " <<< ");
                        }
                        else
                        {
                            Console.WriteLine(" >>> " + diceName [i] + " <<< ");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("  - - - - - - - - - - - - - ");

                cpuDiceName.RemoveAt(cpuindex);
                cpuDiceSide.RemoveAt(cpuindex );

                if (cpuDiceName.Count > 0)
                {
                    Console.WriteLine(" > CPU still got :");
                    Console.WriteLine();
                    for (int i = 0; i < cpuDiceName.Count; i++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine(" > " + cpuDiceName [i] + " < ");
                        }
                        else
                        {
                            Console.WriteLine(" > " + cpuDiceName[i] + " < ");
                        }
                    }
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                Console.WriteLine(" Player: " + playerscore + " points" + $" < Round {round} get: " + playerresult + " >" + " " + "----" + " " + " Computer: " + computerscore + " points" + $" < Round {round} get: " + computerresult + " >");
                Console.WriteLine();
            }

            System.Threading.Thread.Sleep(1300); ///Stop for 1.3 sec to wait the result.
            ///rounds end
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\n              ******** GAME RESULT ******");
            Console.WriteLine();
            if (playerscore > computerscore) ///if playerrescore higher than cpuscore than print.
            {
                Console.WriteLine("Your a lucky player ~~ HA" );
                Console.WriteLine();
                Console.WriteLine(" >> player: " + playerscore);
                Console.WriteLine(" >> CPU: " + computerscore);
            }
            else if (playerscore < computerscore)///if playerscore smaller than cpuscore than print.
            {
                Console.WriteLine("DID YOU JUST LOSE AT CPU ? HA.. NT... HA HA... NT NT");
                Console.WriteLine();
                Console.WriteLine(" >> player: " + playerscore) ;
                Console.WriteLine(" >> CPU: " + computerscore);
            }
            else
            {
                Console.WriteLine("NT you got a tied, with CPU ? NT HA");
                Console.WriteLine();
                Console.WriteLine(" >> player: " + playerscore);
                Console.WriteLine(" >> CPU: " + computerscore);
            }
        }
    }
}
