namespace AlbertDiceGame.Scripts
{
    internal class Program
    {
        /// <summary>
        /// This is the Start of Program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Program Start");
            GameManager manager = new GameManager();
            Console.WriteLine("New GameManager");
            manager.PlayGame();
            Console.WriteLine("Program End");
        }
    }
}
