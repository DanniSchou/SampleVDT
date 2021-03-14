namespace Foxes.Game.Presets.Models.Actors
{
    public class CharacterAction
    {
        public string Name;
        public CheckType AttackType;
        public Ability Ability;
        
        public bool HasAttack()
        {
            return AttackType != CheckType.None;
        }
    }
}