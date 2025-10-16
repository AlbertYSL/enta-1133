using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class Room
    {
        public int Row { get; set; }
        public int Col { get; set; }

        ///four side of rooms 
        public Room North { get; set; }
        public Room South { get; set; }
        public Room East { get; set; }
        public Room West { get; set; }

        public virtual void OnRoomEntered(Combatant player)
        {
            Console.WriteLine($" > {player.GetName()} enter a normal room ");
        }

        public virtual void OnRoomSearched(Combatant player)
        {
            Console.WriteLine(" > There's nothing here ");
        }

        public virtual void OnRoomExit (Combatant player)
        {
            Console.WriteLine($" >>> {player.GetName()} had left the room. ");
        }
    }

    internal class TreasureRoom : Room /// the code for Treasure Room
    {
        private bool taken = false;

        private static Random rd = new Random();

        private string FindJunk()
        {
            string[] junks = { "Broken Old Coin", "Broken Arrow", "Rope", "Dust", "Bone" };
            return junks[rd.Next(junks.Length)];/// so it will be randomly given to the player when they search the door.
        }

        public override void OnRoomSearched(Combatant player)
        {
            if (taken)
            {
                Console.WriteLine("> the box is empty ");
                return;
            }

            /// make the potion not that offen can be find.
            bool givePotion = rd.Next(100) < 30;

            if (givePotion)
            {
                if (player.Dice.CountItem("Potion") >= 5) /// set the player can not take more than 5 bottlo of potion
                {
                    string junk = FindJunk();
                    Console.WriteLine($" >> Ha Ha you found: {junk}");
                    player.AddToBag(junk);
                }
                else
                {
                    Console.WriteLine(" >> You found Potion !");
                    player.AddToBag("Potion");
                }
            }
            else
            {
                string junk = FindJunk();
                Console.WriteLine($" >> you found:{junk} ");
                player.AddToBag(junk);
            }

            taken = true; /// one more once
        }
    }
    internal class MonsterRoom : Room
    {
        private bool firstTime = true;/// when first time the player enter the monster room than the 
        public override void OnRoomEntered(Combatant player)
        {
            if (firstTime)
            {
                Console.WriteLine($" {player.GetName()} a monster jump infront of you !!");
                player.StartMonsterLoop();
                firstTime = false;
            }
            else
            {
                Console.WriteLine(" There's nothing in the room");
            }
        }
    }
    
    internal class BasicRoom : Room
    {
        public override void OnRoomEntered(Combatant player)
        {
            Console.WriteLine($" > {player.GetName()} start at this room ");
        }
    }
}
