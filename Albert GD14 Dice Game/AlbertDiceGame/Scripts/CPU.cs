using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class CPU
    {
        private readonly DiceRoller dice;
        private readonly Combatant player;

        public CPU(Combatant owner)
        {
            dice = new DiceRoller(owner);
            player = owner;
        }
        private int GetDiceDamage(string diceName)
        {
            switch (diceName)
            {
                case "Dice20": return 35;///set Dice20 got 35 damage
                case "Dice12": return 25;///set Dice12 got 25 damage
                case "Dice8": return 20;///set Dice8 got 20 damage
                case "Dice6": return 15;/// set Dice6 got 6 damage
                case "Dice4": return 5;///set Dice4 got 5 damage
                default: return 10;/// set the default damage = 10
            }
        }

        public void ComputerOne()
        {
            Random rand = new Random();

            int playerresult = 0;
            int computerresult = 0;
            int playerscore = 0;
            int computerscore = 0;

            List<string> cpuDiceName = new List<string> { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            List<int> cpuDiceSide = new List<int> { 4, 6, 8, 12, 20 };

            List<string> diceName = new List<string> { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
            List<int> diceSides = new List<int> { 4, 6, 8, 12, 20 };


            int totalRounds = diceName.Count;

            string[] diceType = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };

            for (int round = 1; round <= totalRounds; round++)
            {
                System.Threading.Thread.Sleep(2000); ///Stop for 2 sec to wait the result.

                int cpuindex = rand.Next(cpuDiceSide.Count);
                int cpuSide = cpuDiceSide[cpuindex];

                Console.WriteLine($"\n===== Round {round}/{totalRounds} =====");
                string chosenDic = cpuDiceName[cpuindex];

                int d4 = rand.Next(1, 5);
                int d6 = rand.Next(1, 7);
                int d8 = rand.Next(1, 9);
                int d12 = rand.Next(1, 13);
                int d20 = rand.Next(1, 21);

                if (chosenDic == "Dice4")
                {
                    Console.WriteLine();
                    Console.WriteLine(" > CPU got Dice4");
                    Console.WriteLine($"{d4} points");
                    computerresult = d4;
                }
                else if (chosenDic == "Dice6")
                {
                    Console.WriteLine();
                    Console.WriteLine($" > CPU got Dice6");
                    Console.WriteLine($"{d6} points");
                    computerresult = d6;
                }
                else if (chosenDic == "Dice8")
                {
                    Console.WriteLine();
                    Console.WriteLine($" > CPU got Dice8");
                    Console.WriteLine($"{d8} points");
                    computerresult = d8;
                }
                else if (chosenDic == "Dice12")
                {
                    Console.WriteLine();
                    Console.WriteLine($" > CPU got Dice12");
                    Console.WriteLine($"{d12} points");
                    computerresult = d12;
                }
                else if (chosenDic == "Dice20")
                {
                    Console.WriteLine();
                    Console.WriteLine($" > CPU got Dice20");
                    Console.WriteLine($"{d20} points");
                    computerresult = d20;
                }

                Console.WriteLine();
                int prindex = rand.Next(diceSides.Count);
                int sides = diceSides[prindex];
                string chosenDice = diceName[prindex];

                string[] diceTypes = { "Dice4", "Dice6", "Dice8", "Dice12", "Dice20" };
                string playerchoseDicMessage = "- - - Now, chose your fate --- type 1 to 5.";
                System.Threading.Thread.Sleep(1500); ///Stop for 1.5 sec to wait the result.
                Console.WriteLine(playerchoseDicMessage);
                string userInput = "";
                while (true)
                {
                    string playerretypeMessage = " > T Y P E 1, 2, 3, 4 or 5 @_@";
                    userInput = Console.ReadLine();
                    Console.WriteLine();

                    if (userInput == "1")
                    {
                        Console.WriteLine($"> you got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "2")
                    {
                        Console.WriteLine($"> you got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "3")
                    {
                        Console.WriteLine($">you got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "4")
                    {
                        Console.WriteLine($"> you got {chosenDice} ~~~");
                        break;
                    }
                    else if (userInput == "5")
                    {
                        Console.WriteLine($"> you got {chosenDice} ~~~");
                        break;
                    }
                    else { Console.WriteLine(" > Please Choose Again <"); }
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
                    Console.WriteLine(" >>>> " + "You lose at CPU this round ~~ +_+" + " <<<< ");
                    Console.WriteLine();
                    int damage = GetDiceDamage(chosenDice);
                    Console.WriteLine($" >> You had taken {damage} damage!! TAT ");
                    player.TakeDamage(damage);

                    computerscore += 1;

                    if (player.hp <= 0)
                    {
                        Console.WriteLine("\n ==================== GAME OVER GG =====================");
                        Console.WriteLine("\n ====================== YOU DIED ========================");
                        break;
                    }
                }
                else if (computerresult < playerresult)
                {
                    Console.WriteLine();
                    Console.WriteLine(" >>>> " + "You WIN this round!!" + " <<<< ");
                    int damage = GetDiceDamage(chosenDice);
                    Console.WriteLine($" > Monster takes {damage} damage ");
                    bool dead = player.HurtMonster(damage);
                    playerscore += 1;

                    if (dead)
                    {
                        Console.WriteLine(" >> The Monster ran away ");
                        break;
                    }
                }
                else if (computerresult == playerresult)
                {
                    Console.WriteLine();
                    Console.WriteLine(" >>>> " + "It's a tie =.=" + " <<<< ");
                    playerscore += 1;
                    computerscore += 1;
                }
                Console.WriteLine() ;

                diceName.RemoveAt(prindex);
                diceSides.RemoveAt(prindex);

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
                        ///print the dice name so the player can know what fate he/she still got left.
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
                cpuDiceSide.RemoveAt(cpuindex);

                if (cpuDiceName.Count > 0)
                {
                    Console.WriteLine(" > CPU still got :");
                    Console.WriteLine();
                    for (int i = 0; i < cpuDiceName.Count; i++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine(" > " + cpuDiceName[i] + " < ");
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
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\n             ****** GAME RESULT ******");
            Console.WriteLine();
            if (playerscore > computerscore)
            {
                Console.WriteLine("Your a lucky player ~~ HA");
                Console.WriteLine();
                Console.WriteLine(" >> player: " + playerscore);
                Console.WriteLine(" >> CPU: " + computerscore);
            }
            else if (playerscore < computerscore)
            {
                Console.WriteLine("DID YOU JUST LOSE AT CPU ? HA.. NT... HA HA... NT NT");
                Console.WriteLine();
                Console.WriteLine(" >> player: " + playerscore);
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
