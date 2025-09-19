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
            //Console.WriteLine("New DiceRoller");
            DiceRoller.Dice();

            //OnPointAcquired();
            //OnPointAcquired(25);
            //OnPointAcquired(62);
            //OnPointAcquired(45);
            //int value = 5;
            //OnPointAcquired(value);

            Console.WriteLine("+ : Adds two operands (1 + 1 = 2)");
            Console.WriteLine("- : Sub the second operands from the first (2 - 1 = 1 )");
            Console.WriteLine("/ : Divides the first operands from the second ( 10 / 2 = 5)");
            Console.WriteLine("* : Multiplies two operands ( 5 * 2 = 10 )");
            Console.WriteLine("++: Increases the value of a variable by 1 ( a = 5 ) ( ++a = 6)");
            Console.WriteLine("--: Decreases the value of a variable by 1 ( a = 5 ) ( --a = 4)");
            Console.WriteLine("% : Returns the remainder of an integer division ( 13 / 5 = 2...3) ( 13 % 5 = 3 )");
            //Console.WriteLine("OnPointAcquired");

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