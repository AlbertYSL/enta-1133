using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class GameManager
    {
        private int score = 0;
        private void OnPointAcquired()
        {
            score++;
            string gainedMessage = "You got point";
            Console.WriteLine(gainedMessage);
            Console.WriteLine(score);
        }
        /// <summary>
        /// This is the Start of the Game.
        /// </summary>
        public void PlayGame()
        {
            Console.WriteLine("Welcom Hellow Albert 2025.09.16");
            Console.WriteLine("PlayGame Start");
            DiceRoller roller = new DiceRoller();
            Console.WriteLine("New DiceRoller");
            DiceRoller.Dice();
            //OnPointAcquired();
            //OnPointAcquired(25);
            //OnPointAcquired(62);
            //OnPointAcquired(45);
            //int value = 5;
            //OnPointAcquired(value);
            Console.WriteLine("+");
            Console.WriteLine("-");
            Console.WriteLine("/");
            Console.WriteLine("*");
            Console.WriteLine("++");
            Console.WriteLine("--");
            Console.WriteLine("%");
            Console.WriteLine("OnPointAcquired");
            Console.WriteLine("PlayGame End");
            Console.WriteLine("Goodbye c u");
        }
        void OnPointAcquired(int pointValue)
        {
            int oldScore = score;
            score += pointValue;
            int pointDifference = score - oldScore;
            string gained =
                "You got point " + pointDifference + " points";

            Console.WriteLine(gained);
            Console.WriteLine(score);
        }
    }
    
}