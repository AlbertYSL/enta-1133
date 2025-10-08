using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class Inventory
    {
        private readonly List<string> _items = new List<string>();

        public void AddItem(string name)
        {
            _items.Add(name);
            Console.WriteLine($" you got {name}");
        }

        public void Print()
        {
            Console.WriteLine("your bag: ");
            if (_items.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"[{i}] {_items[i]}");
            }
            Console.WriteLine($" Item number: {_items.Count}");
        }
    }
}
