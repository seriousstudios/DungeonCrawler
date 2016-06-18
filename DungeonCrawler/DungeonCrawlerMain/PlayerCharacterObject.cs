using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerMain
{
    public class PlayerCharacterObject : GameObject
    {
        public PlayerCharacterObject()
        {
            Attributes.Add(new StrengthScoreAttribute());
            Attributes.Add(new DexterityScoreAttribute());
            Attributes.Add(new ConstitutionScoreAttribute());
            Attributes.Add(new IntelligenceScoreAttribute());
            Attributes.Add(new WisdomScoreAttribute());
            Attributes.Add(new CharismaScoreAttribute());
        }
    }
}
