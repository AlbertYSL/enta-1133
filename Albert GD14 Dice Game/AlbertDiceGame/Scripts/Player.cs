using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class Player
    {
        public void Introduction()
        {
            ///Asking what's the player name, read the playername by userInput.
            string askenameMessge = "What is your name";
            Console.WriteLine(askenameMessge);
            Console.WriteLine("******************************************************************");
            string playerName = Console.ReadLine();
            Console.WriteLine("******************************************************************");
            Console.WriteLine();

            Console.WriteLine(" > Starting the Rules of the Game.");
            string pressenterMessage = " > Please press Enter to continue.";
            Console.WriteLine(pressenterMessage);
            //Contiue to next event by pressing Space.
            Console.WriteLine();
            Console.WriteLine("(＾.＾) (*^3^*) (>_<) (//3//) (* ω *) (= ω = ) (T....T) ( @.@ )");
            string userInput = Console.ReadLine();
            userInput = "Enter";

            Console.WriteLine(" > Both players get five different dice (d4, d6, d8, d12, d20)");
            Console.WriteLine(" > Then, randomly choose a number.");
            Console.WriteLine(" > After players have chosen a number, the die will roll.");
            Console.WriteLine(" > See who got the highest roll.");
            Console.WriteLine(" > Highest score wins the round.");
            Console.WriteLine(" > The dice you have already rolled will be gone for the rest of the game. ");
            Console.WriteLine(" > After the round, you need to choose a different die.");
            Console.WriteLine(" > Continue until both of the players' dice have all been used.");
            Console.WriteLine(" > The player who wins the most rounds wins the GAME.");
            Console.WriteLine();
            Console.WriteLine("( @.@ ) (T....T) (= ω = ) (* ω *) (//3//) (>_<) (*^3^*) (＾.＾)");

            Console.WriteLine();
            Console.WriteLine($"Now,{playerName} Would you like to play?? ");/// Read the PlayerName
            Console.WriteLine("Yes = 1, No = 2");

            while (true)  ///This code is for letting the player cant type anything else, only 1 or 2.
            {
                string playerreplayMessage = "1 or 2";
                userInput = Console.ReadLine(); /// that the player type 1 or 2 for Yes or No
                Console.WriteLine();
                if (userInput == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Let's go !!");
                    break; /// Break the loop, so can go on to the next event.
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Too late ~ ~ Still need to play ^ . ^ ");
                    break;
                    Console.WriteLine();
                }
                else { Console.WriteLine($" {playerName} Only Yes or No ~ isn't that hard to read +_+ ..."); } /// if player type something else they will see this message can retype (because only 1 or 2 can break the loop).
                Console.WriteLine(playerreplayMessage);
            }
        
                Console.WriteLine();
                bool onemoreTime = true;
            while (onemoreTime) /// use the loop by while, so when the player end the game will ask them if they want to play again or not.
            {
                Console.WriteLine();
                Random rm = new Random(); /// making the random = rm
                Console.WriteLine("Let's see who goes first $_$");
                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                int turn = rm.Next(0, 2);/// so it'll only give 0 or 1.
                //DiceRoller dr = new DiceRoller();
                //CPU cpu = new CPU();


                if (turn == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{playerName} starts first"); /// if 0 than it's player start first = by link to the playername that player type at the Console.ReadLine
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    //dr.PlayerOne(); /// open the PlayerOne (player code) in DiceRoller.
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Starting from cpu one ...."); /// if 1 shows up than it'll be the CPU to start first.
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    //cpu.ComputerOne();/// open the ComputerOne (CPU code) in DiceRoller.
                    Console.WriteLine();
                }

                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                Console.WriteLine("\n>>>> Wanna try again ? 1 = yes or type anythings else = no <<<<");
                userInput = Console.ReadLine();
                onemoreTime = (userInput == "1");
                Console.WriteLine();
                if (onemoreTime)
                {
                    Console.Clear(); ///clear all the rounds and restart from choose who go first.
                }
            }
            System.Threading.Thread.Sleep(1500); ///Stop for 1.5 sec to wait the result.
            Console.WriteLine($"{playerName} thank you for playing, see you ^_^!!");
            Console.WriteLine(@" 
                                 ______   _______   ______   _______        ____    _____     ____  
                                | __ ) \ / / ____| | __ ) \ / / ____|      / __ \  |___ /    / __ \ 
                                |  _ \\ V /|  _|   |  _ \\ V /|  _|       / / _` |   |_ \   / / _` |
                                | |_) || | | |___  | |_) || | | |___     | | (_| |  ___) | | | (_| |
                                |____/ |_| |_____| |____/ |_| |_____|     \ \__,_| |____/   \ \__,_|
                                                                           \____/            \____/  ");
        }

    }

}
