namespace Foxes.Game.Presets.Models.Actors
{
    public class Damage
    {
        public int Count;
        public int Value;
        public string Name;
        
        public bool UseFixedValue;
        public int FixedValue;

        public void UpdateName()
        {
            Name = $"{Count}d{Value}";
        }

        public Damage Clone()
        {
            return new Damage
            {
                Count = Count,
                Value = Value,
                Name = Name,
                UseFixedValue = UseFixedValue,
                FixedValue = FixedValue
            };
        }
    }
}