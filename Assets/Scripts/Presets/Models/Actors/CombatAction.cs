namespace Foxes.Game.Presets.Models.Actors
{
    public class CombatAction : CharacterAction
    {
        public Damage Damage;
        public int Bonus;
        public WeaponType WeaponType;

        public CombatAction Clone()
        {
            return new CombatAction
            {
                Name = Name,
                AttackType = AttackType,
                Ability = Ability,
                Damage = Damage.Clone(),
                Bonus = Bonus,
                WeaponType = WeaponType
            };
        }
    }
}