using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterRPG.Managers
{
    internal class UserInterface
    {
        public static string GetInput()
        {
            Console.Write("> ");
            return Console.ReadLine() ?? string.Empty;
        }

        public static void DisplayTilte(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(title.PadLeft(25 + title.Length / 2));
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
