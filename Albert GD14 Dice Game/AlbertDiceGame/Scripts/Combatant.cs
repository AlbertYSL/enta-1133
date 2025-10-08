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
        private readonly Inventory bag; /// player bag 
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
            bag = new Inventory();
            rooms = new List<Room>();
            Console.WriteLine();

            Console.WriteLine("What is your name Maze Explorer: "); /// asking name of the player
            playerName = Console.ReadLine();

            Console.WriteLine();
            ///basic map 
            BuildFixedRooms();
            LinkNeighbors();
            SetStartAtCenter();
        }

        public void AddToBag(string items)
        {
            bag.AddItem(items);/// makesure that bag is in Inventory
        }

        public string GetName()
        {
            return playerName; ///Let the code know the playername so it can be used
        }

        public void StartEncounterLoop() ///call out the battle
        {
            Console.WriteLine("[Encounter] Strat ");
            Console.WriteLine("[Encounter] End");
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
                if (choice == "1") { current.OnRoomEntered(this); ShowMap(); InsideRoom(); }
                else if (choice == "2") { AskMove(); }
                else if (choice == "3") { bag.Print(); }
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
                else if (choice == "2") bag.Print();
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
            Console.WriteLine();
        }
    }
}
