namespace AlbertDiceGame.Scripts
{
    internal class Program
    {
        /// <summary>
        /// This is the Start of Program.
        /// </summary>
        static void Main(string[] args)
        {
            //GameManager manager = new GameManager();
            //manager.PlayGame();

            Console.WriteLine(@"
                                __        __   _                            _          _   _          
                                \ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
                                 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
                                  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
                                 __\_/\_/ \___|_|\___\___/|_| |_| |_|\___|__\__\___/   \__|_| |_|\___|
                                                           _____ ___ _
                                                          |  ___|_ _| |_ ___   
                                                          | |_ / _` | __/ _ \ 
                                                          |  _| (_| | ||  __/   
                                                          |_|  \__,_|\__\___| ");

            Combatant combatant = new Combatant();
            combatant.GameStart();
        }
    }
}
