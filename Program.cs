using HunterRPG.Managers;

namespace HunterRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameManager();
            game.Start();
        }
    }
}
