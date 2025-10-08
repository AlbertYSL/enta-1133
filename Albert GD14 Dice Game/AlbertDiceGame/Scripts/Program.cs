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
           Combatant combatant = new Combatant();
            combatant.GameStart();
        }
    }
}
