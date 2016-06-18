using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawlerMain;

namespace DungeonCrawlerConsole
{
    class ConsoleResponder : DungeonCrawlerMain.IResponder
    {
        public void ChangeBackgroundColour()
        {
            Console.WriteLine("Behold, the colour before you changes to a stunning red! Two seconds later, it changes to a stunning blue!");
        }

        public PlayerCharacterObject CreatePlayerCharacter()
        {
            PlayerCharacterObject player = new PlayerCharacterObject();

            var playerCharacterAbilityScores = player.Attributes.OfType<AbilityScoreAttribute>();

            foreach (AbilityScoreAttribute ability in playerCharacterAbilityScores)
            {
                ability.RandomlyRollAbilityScore();
            }

            return player;
        }

        public void ShowPlayerCharacterInformation(PlayerCharacterObject player)
        {
            var playerCharacterAbilityScores = player.Attributes.OfType<AbilityScoreAttribute>();

            foreach (AbilityScoreAttribute ability in playerCharacterAbilityScores)
            {
                int modifier = ability.CalculateModifier();

                Console.WriteLine(ability.ComponentName + ": " + ability.Value.ToString() + 
                    " (" + (modifier > 0 ? "+" : "") + modifier.ToString() + ")");
            }
        }
    }
}
