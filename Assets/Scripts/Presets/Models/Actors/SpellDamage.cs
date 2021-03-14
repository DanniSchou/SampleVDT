namespace Foxes.Game.Presets.Models.Actors
{
    public class SpellDamage
    {
        public int Level;
        public Damage Damage;

        public string GetLevelText()
        {
            return Level switch
            {
                0 => "Cantrip",
                1 => "1st",
                2 => "2nd",
                3 => "3rd",
                _ => $"{Level}th"
            };
        }
    }
}