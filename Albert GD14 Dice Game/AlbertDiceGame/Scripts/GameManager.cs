using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlbertDiceGame.Scripts
{
    internal class GameManager
    {
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

            Combatant cmbt = new Combatant();
            cmbt.GameStart();
        }
    }
    
}