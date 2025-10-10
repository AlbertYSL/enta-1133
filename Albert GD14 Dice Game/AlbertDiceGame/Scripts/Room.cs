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

        public override void OnRoomSearched(Combatant player)
        {
            if (!taken)///if ! = not taken it'll randonly shows the item you got.
            {
                string[] items = { "d4, d6, d8, d12, d20", "Potion", "Long Sword", "Arrow and Bow", "Short Sword" };
                string found = items[rd.Next(items.Length)];

                Console.WriteLine($"you found {found}! ");
                player.AddToBag(found);

                taken = true;
            }
            else/// if already taken it'll shows that the box is empty
            {
                Console.WriteLine(" The box is empty ");
            }
        }
    }

    internal class EncounterRoom : Room
    {
        private bool firstTime = true;
        public override void OnRoomEntered(Combatant player)
        {
            if (firstTime)
            {
                Console.WriteLine($" {player.GetName()} a monster jump infront of you !!");
                player.StartEncounterLoop();
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
