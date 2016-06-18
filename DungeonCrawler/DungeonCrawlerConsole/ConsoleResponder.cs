using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerConsole
{
    class ConsoleResponder : DungeonCrawlerMain.IResponder
    {
        public void ChangeBackgroundColour()
        {
            Console.WriteLine("Behold, the colour before you changes to a stunning red! Two seconds later, it changes to a stunning blue!");
        }
    }
}
