using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerMain
{
    public class DungeonCrawlerMain
    {
        public void Run(IResponder responder)
        {
            PlayerCharacterObject player = responder.CreatePlayerCharacter();

            responder.ChangeBackgroundColour();
            responder.ShowPlayerCharacterInformation(player);
        }
    }
}
