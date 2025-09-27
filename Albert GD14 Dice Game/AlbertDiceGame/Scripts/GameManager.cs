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
            Console.WriteLine("Welcome! Hello my name is Albert and today is 2025.09.21");
            Console.WriteLine("This is a dice game we came up with.");
            Console.WriteLine();
            Player pr = new Player();
            Player.Playerone();

            //OnPointAcquired();
            //OnPointAcquired(25);
            //OnPointAcquired(62);
            //OnPointAcquired(45);
            //int value = 5;
            //OnPointAcquired(value);
            //Console.WriteLine("OnPointAcquired");
            Console.WriteLine();
            Console.WriteLine("Thank you for playing, see you ^_^!!");
            //Console.WriteLine("PlayGame End");
            //Console.WriteLine("Goodbye see you next time~ ");
        }
    }
    
}