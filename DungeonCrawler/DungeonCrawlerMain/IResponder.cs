using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerMain
{
    // Interface which defines how to comunicate between the console and monogame
    public interface IResponder
    {
        void ChangeBackgroundColour();
        PlayerCharacterObject CreatePlayerCharacter();
        void ShowPlayerCharacterInformation(PlayerCharacterObject player);
    }
}
