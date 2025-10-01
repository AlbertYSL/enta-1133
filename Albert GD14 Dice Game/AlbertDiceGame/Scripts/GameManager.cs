using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class GameManager
    {
        //private int score = 0;
        private void OnPointAcquired()
        {
            //score++;
            //string gainedMessage = "You got point";
            //Console.WriteLine(gainedMessage);
            //Console.WriteLine(score);
        }
        /// <summary>
        /// This is the Start of the Game.
        /// </summary>
        public void PlayGame()
        {
            /// add a @ for the ASCII code so the the space and the lines can be count and run or else the ASCII code will be a mass up.
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
            Console.WriteLine("My name is Albert");
            Console.WriteLine("This is a dice game we came up with.");
            Console.WriteLine();
            Player pr = new Player();
            Player.Playerone();/// open the playerone in the Player.cs

            //OnPointAcquired();
            //OnPointAcquired(25);
            //OnPointAcquired(62);
            //OnPointAcquired(45);
            //int value = 5;
            //OnPointAcquired(value);
            //Console.WriteLine("OnPointAcquired");
            Console.WriteLine();
            //Console.WriteLine("Thank you for playing, see you ^_^!!");
            Console.WriteLine();
            //Console.WriteLine("PlayGame End");
            //Console.WriteLine("Goodbye see you next time~ ");
        }
    }
    
}