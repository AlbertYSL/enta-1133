using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class Combatant
    {
        private int hp = 100; /// player hp start from 100
        private readonly DiceRoller dice; /// player bag 
        private readonly Random rd; 
        private string playerName; ///player name

        private readonly int rows = 3; /// 3 X 3 rooms map
        private readonly int cols = 3;
        private List<Room> rooms; /// make a list to every rooms I got
        private Room current; /// set the current room that the player is at
        private int curRw, curCl;

        public Combatant()
        {
            rd = new Random();
            rooms = new List<Room>();
            dice = new DiceRoller();
            Console.WriteLine();

            Console.WriteLine(@"
                                __        __   _                            _          _   _          
                                \ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
                                 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
                                  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
                                 __\_/\_/ \___|_|\___\___/|_| |_| |_|\___|__\__\___/   \__|_| |_|\___|
                                |  ___|_ _| |_ ___  |  _ \(_) ___ ___   / ___| __ _ _ __ ___   ___    
                                | |_ / _` | __/ _ \ | | | | |/ __/ _ \ | |  _ / _` | '_ ` _ \ / _ \   
                                |  _| (_| | ||  __/ | |_| | | (_|  __/ | |_| | (_| | | | | | |  __/   
                                |_|  \__,_|\__\___| |____/|_|\___\___|  \____|\__,_|_| |_| |_|\___|");

            Console.WriteLine();
            Console.WriteLine("What is your name Maze Explorer: "); /// asking name of the player
            playerName = Console.ReadLine();

            Console.WriteLine();
            ///basic map detail
            BuildFixedRooms();
            LinkNeighbors();
            SetStartAtCenter();
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
        }

        public void AddToBag(string items)
        {
            dice.AddItem(items);/// makesure that bag is in Inventory
        }

        public string GetName()
        {
            return playerName; ///Let the code know the playername so it can be used
        }

        public void StartEncounterLoop() ///call out the battle
        {
            //GameManager diceGame = new GameManager();
            //diceGame.PlayGame();
            Console.WriteLine("[Fath] Strat ");
            bool onemoreTime = true;
            while (onemoreTime) /// use the loop by while, so when the player end the game will ask them if they want to play again or not.
            {
                Console.WriteLine();
                Random rm = new Random(); /// making the random = rm
                Console.WriteLine("Let's see who goes first $_$");
                Console.WriteLine(" > please type enter to continue");
                Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++");
                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                int turn = rm.Next(0, 2);/// so it'll only give 0 or 1.
                DiceRoller dr = new DiceRoller();
                CPU cpu = new CPU();

                string userInput = Console.ReadLine();

                if (turn == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{playerName} starts first"); /// if 0 than it's player start first = by link to the playername that player type at the Console.ReadLine
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    dr.PlayerOne(); /// open the PlayerOne (player code) in DiceRoller.
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Starting from cpu one ...."); /// if 1 shows up than it'll be the CPU to start first.
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    cpu.ComputerOne();/// open the ComputerOne (CPU code) in DiceRoller.
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
            Console.WriteLine("[Fath] End");
        }

        public void GameStart()
        {
            Console.WriteLine($"\n Welcome {playerName} the Maze Explorer!");
            
            while (true)  ///This code is for letting the player cant type anything else, only 1 or 2.
            {
                Console.WriteLine("Are you ready for the Adventure? 1 = Yes, 2 = No");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Start the advanture!!");
                    break; /// Break the loop, so can go on to the next event.
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Ok, see you.");
                    return;
                }
                else { Console.WriteLine($" {playerName} Only Yes or No ~ isn't that hard to read +_+ ..."); } /// if player type something else they will see this message can retype (because only 1 or 2 can break the loop).
            }

            Console.WriteLine("====== Dice of Fath ======");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"\n > now {playerName} there is a door infront to you, what do you want to do next?");
                Console.WriteLine(" > 1 = enter the room, 2 = dont enter the room, 3 = check your bag, 4 = check your hp");
                ///Let the player chose what they want to do next by type down 1, 2, 3, 4.
                Console.WriteLine();

                var choice = Console.ReadLine();
                if (choice == "1") { current.OnRoomEntered(this); ShowMap(); InsideRoom(); }/// when type 1 the current room itself(this) will be open and also showmap and what's inside tha room will be open too by insideroom()
                else if (choice == "2") { AskMove(); }/// type 2 will beable to open the AskMove code 
                else if (choice == "3") { dice.Print(); }/// cause the bag code is in the diceroller part (player class) so use dice.Print to link and open it.
                else if (choice == "4") { Console.WriteLine($" > {playerName} got: {hp}"); }
                else Console.WriteLine($" {playerName} please enter 1, 2, 3 or 4");
            }
        }

        private void InsideRoom() /// set the code when the player is inside the room
        {
            bool inside = true; /// if the player is inside the room = ture, so the code will run
            while (inside)
            {
                Console.WriteLine($"\n {playerName} had enter the room, what are you going to do next?");
                Console.WriteLine(" > 1 = search the door, 2 = check your bag, 3 = check your hp, 4 = go to another room");

                var choice = Console.ReadLine();

                if (choice == "1") current.OnRoomSearched(this);
                else if (choice == "2") dice.Print();
                else if (choice == "3") Console.WriteLine($"{playerName} got: {hp}");
                else if (choice == "4") { AskMove(); inside = false; }
                else Console.WriteLine($" {playerName} please enter 1, 2, 3 or 4");
            }

        }

        private void AskMove()/// if the player choiced 4 than this code will run by asking what is their next move 
        {
            Console.WriteLine($"{playerName} where do you wnat to expore?");
            Console.WriteLine(" W = going up, A = going left, S = going down, D = going rihgt"); /// the way the player want to go to by typing w, a, s, d
            string mov = Console.ReadLine();

            if (mov == "w") Move(current.North, -1, 0);
            else if (mov == "s") Move(current.South, +1, 0);
            else if (mov == "a") Move(current.West, 0, -1);
            else if (mov == "d") Move(current.East, 0, +1);
            else { Console.WriteLine($" {playerName} please enter w, a ,s or d"); }

            Console.WriteLine();
            current.OnRoomEntered(this);
            ShowMap();
        }

        private void Move(Room next, int dR, int dC)
        ///use int dR to the amount of change in row how many columns to move up/down.
        ///use int dC to the amount of change in col (how many rows to move left/right)
        {
            if (next == null) { Console.WriteLine($" {playerName} what's a wall brother, you can't go there."); return; }
            current.OnRoomExit(this);
            curRw += dR;
            curCl += dC;
            current = next;
            Console.WriteLine($" {playerName} move to ({curRw}, {curCl})");
        }

        private void BuildFixedRooms()
        {
            rooms.Clear(); /// clear the rooms

            ///The first row
            rooms.Add(new EncounterRoom { Row = 0, Col = 0 });
            rooms.Add(new TreasureRoom { Row = 0, Col = 1 });
            rooms.Add(new EncounterRoom { Row = 0, Col = 2 });

            ///The second row
            rooms.Add(new TreasureRoom { Row = 1, Col = 0 });
            rooms.Add(new BasicRoom { Row = 1, Col = 1 });
            rooms.Add(new TreasureRoom { Row = 1, Col = 2 });

            ///The third row
            rooms.Add(new TreasureRoom { Row = 2, Col = 0 });
            rooms.Add(new TreasureRoom { Row = 2, Col = 1 });
            rooms.Add(new EncounterRoom { Row = 2, Col = 2 });
        }

        private void LinkNeighbors()
        {
            ///connet the 9 rooms 
            ///First row
            rooms[0].East = rooms[1];// (0, 0) go right (0, 1)
            rooms[0].South = rooms[3];// (0, 0) go down (1, 0)

            rooms[1].West = rooms[0];
            rooms[1].East = rooms[2];
            rooms[1].South = rooms[4];

            rooms[2].West = rooms[1];
            rooms[2].South = rooms[5];

            //Second row
            rooms[3].North = rooms[0];
            rooms[3].East = rooms[4];
            rooms[3].South = rooms[6];

            rooms[4].North = rooms[1];
            rooms[4].West = rooms[3];
            rooms[4].East = rooms[5];
            rooms[4].South = rooms[7];

            rooms[5].North = rooms[2];
            rooms[5].West = rooms[4];
            rooms[5].South = rooms[8];

            //Third row
            rooms[6].North = rooms[3];
            rooms[6].East = rooms[7];

            rooms[7].North = rooms[4];
            rooms[7].West = rooms[6];
            rooms[7].East = rooms[8];

            rooms[8].North = rooms[5];
            rooms[8].West = rooms[7];
        }

        private void SetStartAtCenter()
        {
            curRw = 1;
            curCl = 1;
            current = rooms[4]; /// center room of the map
            Console.WriteLine($" > {playerName} start from this room, let's goooo! ");
        }
        public void ShowMap()
        {
            Console.WriteLine();
            for (int r = 0; r < 3; r++)/// r = 0 is the first row and every time player run once it will moved to next one by ++ = +1
            {
                for (int c = 0; c < 3; c++)
                {
                    if (r == curRw && c == curCl)
                        Console.Write("[X]");/// use console.write for not changing the line into next line
                    else Console.Write("[ ]");
                }
                Console.WriteLine();
            }
        }
        
    }
}
