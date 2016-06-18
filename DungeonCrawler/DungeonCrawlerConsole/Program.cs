using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console game has started...");

            DungeonCrawlerMain.DungeonCrawlerMain main = new DungeonCrawlerMain.DungeonCrawlerMain();
            ConsoleResponder responder = new ConsoleResponder();

            main.Run(responder);

            Console.WriteLine("Console game has ended...");
            Console.ReadKey();
        }
    }
}
