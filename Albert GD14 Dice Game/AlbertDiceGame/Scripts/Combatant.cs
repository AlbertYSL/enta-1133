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

        public int hp = 100; /// player hp start from 100
        private readonly DiceRoller dice; /// player bag 
        public DiceRoller Dice => dice;
        private readonly Random rd; 
        private string playerName; ///player name
        public static Combatant player;/// set it at static so it would be only one and not change 
        public int MonsterHP = 100;

        public void ResetMonster()
        {
            MonsterHP = 100;
        }

        public bool HurtMonster(int dmg)
        {
            MonsterHP -= dmg;
            Console.WriteLine($" >> Monster - {dmg} HP ");
            Console.WriteLine($" >> remain : {MonsterHP}");
            return MonsterHP <= 0;/// return to see if the monsters' hp get to 0 over not 
        }
        private readonly int rows = 3; /// 3 X 3 rooms map
        private readonly int cols = 3;
        private List<Room> rooms; /// make a list to every rooms I got
        private Room current; /// set the current room that the player is at
        private int curRw, curCl;

        public Combatant()
        {
            rd = new Random();
            rooms = new List<Room>();
            dice = new DiceRoller(this);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("What is your name Maze Explorer: "); /// asking name of the player
            playerName = Console.ReadLine();

            Console.WriteLine();
        }

        private const int MaxHP = 100; /// set the MaxHP at 100. 

        public void Heal(int amount)
        {
            if (hp >= 100)
            {
                Console.WriteLine(" >> Your HP is already Full ");
                return;
            }
            int old =hp;
            hp += amount;
            if (hp > 100) hp = 100;
            Console.WriteLine();
            Console.WriteLine($" >> {playerName} had healed {hp - old} HP  ");
            Console.WriteLine($" >> HP : {hp}/100 ");
        }
        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
            Console.WriteLine($" >> {playerName} took {damage} damage !! TAT");
            Console.WriteLine($" >> HP : {hp}/100 ");
            
            if (hp <= 0) GameOver();
        }

        private void GameOver()
        {
            if (hp > 0) return;
            Console.WriteLine("\n ==================== GAME OVER GG =====================");
            Console.WriteLine("\n ====================== YOU DIED ========================");
            Console.WriteLine();
            Console.WriteLine(" Would you like to try again ?");
            Console.WriteLine(">> Yes = 1 ");
            Console.WriteLine(">> Give up = 2 ");
            
            string yes = Console.ReadLine();
            if (yes == "1")
            {
                hp = 100;
                ResetMonster();
                rooms.Clear();
                BuildRandomRooms();
                LinkNeighbors();
                SetStartAtCenter();
                Console.WriteLine(" >>> RESTART <<<");
            }
            else
            {
                System.Threading.Thread.Sleep(1500); ///Stop for 1.5 sec to wait the result.
                Environment.Exit(0);
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

        private void UsePotion()
        {
            dice.Print(); //The place for the bag code
            if (!dice.HasItem("Potion")) /// if the player bag do not had the Item name Potion.
            {
                Console.WriteLine("( No Potion in your bag )");
                return;
            }
            if (hp >= MaxHP) /// if the player hp is at > or = to 100
            {
                Console.WriteLine(" >>> Your HP is Full can't use the potion. ");/// print
                return;
            }

            Console.WriteLine(" Do you wnat to use Potion for +30 hp ?");
            Console.WriteLine(">> Yes = 1 ");
            Console.WriteLine(">> No = 2 ");

            string yep = Console.ReadLine();
            if ( yep == "1") /// if player enter 1 
            {
                if (dice.RemoveOne("Potion")) Heal(30); /// open the removeOne code and remove one potion 
                else Console.WriteLine( "> There is no Potion in your bag ");
            }
            else
            {
                Console.WriteLine();
            }
        }

        public void AddToBag(string items)
        {
            dice.AddItem(items);/// makesure that bag is in Inventory
        }

        public string GetName()
        {
            return playerName; ///Let the code know the playername so it can be used
        }

        public void GameStart()
        {
            Console.WriteLine($"\n Welcome {playerName} the Maze Explorer!");

            while (true)  ///This code is for letting the player cant type anything else, only 1 or 2.
            {
                Console.WriteLine(" Are you ready for the Adventure? ");
                Console.WriteLine(" > 1 = Yes ");
                Console.WriteLine(" > 2 = No ") ;

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
            Console.WriteLine() ;

            ///basic call for the rooms and start center 
            BuildRandomRooms();
            LinkNeighbors();
            SetStartAtCenter();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"\n > now {playerName} there is a door infront to you, what do you want to do next?");
                Console.WriteLine(" > 1 = enter the room ");
                ///Let the player chose what they want to do next by type down 1, 2, 3, 4.
                Console.WriteLine(" > 2 = dont enter the room ");
                Console.WriteLine(" > 3 = check your bag ");
                Console.WriteLine(" 4 = check your hp ");
                Console.WriteLine();

                var choice = Console.ReadLine();
                if (choice == "1") { current.OnRoomEntered(this); ShowMap(); InsideRoom(); }/// when type 1 the current room itself(this) will be open and also showmap and what's inside tha room will be open too by insideroom()
                else if (choice == "2") { AskMove(); }/// type 2 will beable to open the AskMove code 
                else if (choice == "3") { UsePotion(); } /// when the player check their bag if thre's potion inside the bag then it'll ask if the player want to use it or not 
                else if (choice == "4") { Console.WriteLine($" > {playerName} got: {hp}"); }
                else Console.WriteLine($" {playerName} please enter 1, 2, 3 or 4");
            }
        }


        private void SetStartAtCenter()
        {
            curRw = 1;
            curCl = 1;
            current = rooms[4]; /// center room of the map
            Console.WriteLine($" > {playerName} start from this room, let's goooo! ");
            ShowMap();
        }

        private void InsideRoom() /// set the code when the player is inside the room
        {
            bool inside = true; /// if the player is inside the room = ture, so the code will run
            while (inside)
            {
                Console.WriteLine($"\n {playerName} had enter the room, what are you going to do next?");
                Console.WriteLine(" >> 1 = search the door ");
                Console.WriteLine(" >> 2 = check your bag ");
                Console.WriteLine(" >> 3 = check your hp ");
                Console.WriteLine(" >> 4 = go to another room ");
                Console.WriteLine();

                var choice = Console.ReadLine();

                if (choice == "1") current.OnRoomSearched(this);
                else if (choice == "2") UsePotion();
                else if (choice == "3") Console.WriteLine($"{playerName} got: {hp}");
                else if (choice == "4") { AskMove(); inside = false; }
                else Console.WriteLine($" {playerName} please enter 1, 2, 3 or 4");
            }

        }

        private void AskMove()/// if the player choiced 4 than this code will run by asking what is their next move 
        {
            Console.WriteLine($"{playerName} where do you wnat to expore?");
            Console.WriteLine(" W = North, A = South, S = West, D = East"); /// the way the player want to go to by typing w, a, s, d
            string mov = Console.ReadLine();

            if (mov == "w") Move(current.North, -1, 0); /// set w == to going North (up) and -1, 0 = one step up
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

        private void BuildRandomRooms()
        {
            rooms.Clear(); /// clear the rooms

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    rooms.Add(new TreasureRoom { Row = r , Col = c });
                }
            }

            rooms[4] = new BasicRoom { Row = 1 , Col = 1 }; /// set the middle spown room, so it will not invote into the random.

            Random rdm = new Random();
            int monster = 0;
            while (monster < 3)///only 3 random room will be change into monster room.
            {
                int pos = rdm.Next(0, 9);
                if (pos == 4 ) continue; /// if the pos (position) is 4 than cant be the middle room
                if (rooms[pos] is MonsterRoom) continue; /// if the room already is a monster room than it'll jump over to next room for choosing the random room
                
                rooms[pos] = new MonsterRoom {Row = pos / 3, Col = pos % 3}; /// use postition / by 3 to see which row should it be. use position % 3 to see which column.
                monster++;/// to see if there already a monster than jump to next random chose and add one until 3 monster room shows.
            }
        }

        public void StartMonsterLoop() ///call out the battle
        {
            DiceRoller dr = new DiceRoller(this);
            //GameManager diceGame = new GameManager();
            //diceGame.PlayGame();
            Console.WriteLine("[Battle] Strat ");
            bool onemoreTime = true;
            while (onemoreTime) /// use the loop by while, so when the player end the game will ask them if they want to play again or not.
            {
                Console.WriteLine();
                Random rm = new Random(); /// making the random = rm
                Console.WriteLine(">>Let's see who goes first $_$");
                Console.WriteLine(" > please type enter to start the FATH ");
                Console.WriteLine();
                Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++ ");
                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                int turn = rm.Next(0, 2);/// so it'll only give 0 or 1.
                //DiceRoller dr = new DiceRoller();
                CPU cpu = new CPU(this);
                cpu.ComputerOne();

                string userInput = Console.ReadLine();

                if (turn == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($" * {playerName} starts first"); /// if 0 than it's player start first = by link to the playername that player type at the Console.ReadLine
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    dr.PlayerOne(); /// open the PlayerOne (player code) in DiceRoller.
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" * Starting from cpu one ...."); /// if 1 shows up than it'll be the CPU to start first.
                    Console.WriteLine("The dice will be randomly given to you every round.");
                    cpu.ComputerOne();/// open the ComputerOne (CPU code) in DiceRoller.
                    Console.WriteLine();
                }

                System.Threading.Thread.Sleep(1000); ///Stop for 1 sec to wait the result.
                Console.WriteLine("\n>>>> Wanna try again ? 1 = yes or type anythings else to countinue your adventure <<<<");
                userInput = Console.ReadLine();
                onemoreTime = (userInput == "1");
                Console.WriteLine();
                if (onemoreTime)
                {
                    Console.Clear(); ///clear all the rounds and restart from choose who go first.
                }
            }
            Console.WriteLine("[Battle] End");
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
