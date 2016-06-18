using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerMain
{
    public abstract class AbilityScoreAttribute : IntegerAttribute
    {
        public AbilityScoreAttribute(string abilityScoreName)
            : base(abilityScoreName + " Ability Score")
        { }

        public int CalculateModifier()
        {
            // e.g 6 / 2 = 3 (-5 = -2)
            // e.g 5 / 2 = 2 (-5 = -3) (working in integers so chop off end of decimal)
            return Value / 2 - 5;
        }

        public void RandomlyRollAbilityScore()
        {
            List<int> rolls = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                rolls.Add(GlobalHelper.Random.Next(1, 7));
            }

            rolls.Remove(rolls.Min());

            int sum = 0;
            foreach (int n in rolls)
                sum += n;

            Value = sum;
        }
    }

    public class StrengthScoreAttribute : AbilityScoreAttribute
    {
        public StrengthScoreAttribute()
            : base("Strength")
        { }
    }

    public class DexterityScoreAttribute : AbilityScoreAttribute
    {
        public DexterityScoreAttribute()
            : base("Dexterity")
        { }
    }

    public class ConstitutionScoreAttribute : AbilityScoreAttribute
    {
        public ConstitutionScoreAttribute()
            : base("Constitution")
        { }
    }

    public class IntelligenceScoreAttribute : AbilityScoreAttribute
    {
        public IntelligenceScoreAttribute()
            : base("Intelligence")
        { }
    }

    public class WisdomScoreAttribute : AbilityScoreAttribute
    {
        public WisdomScoreAttribute()
            : base("Wisdom")
        { }
    }

    public class CharismaScoreAttribute : AbilityScoreAttribute
    {
        public CharismaScoreAttribute()
            : base("Charisma")
        { }
    }
}
