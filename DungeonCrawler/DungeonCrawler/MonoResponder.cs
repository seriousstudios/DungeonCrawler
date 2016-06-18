using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;
using DungeonCrawlerMain;

namespace DungeonCrawler
{
    class MonoResponder : DungeonCrawlerMain.IResponder
    {
        Game1 game;
        EventWaitHandle waitHandler = new AutoResetEvent(false);

        public MonoResponder(Game1 game)
        {
            this.game = game;
        }

        void suspend(TimeSpan timeout)
        {
            waitHandler.WaitOne(timeout);
        }

        void resume()
        {
            waitHandler.Set();
        }

        public void ChangeBackgroundColour()
        {
            game.BackgroundColour = Color.Red;
            suspend(TimeSpan.FromSeconds(2.0));
            game.BackgroundColour = Color.SteelBlue;
        }

        public PlayerCharacterObject CreatePlayerCharacter()
        {
            throw new NotImplementedException();
        }

        public void ShowPlayerCharacterInformation(PlayerCharacterObject player)
        {
            throw new NotImplementedException();
        }
    }
}
