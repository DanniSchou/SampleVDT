namespace Foxes.Game.Themes.Models
{
    using Rolls;
    using UnityEngine;

    [CreateAssetMenu]
    public class DiceSkin : ScriptableObject
    {
        [SerializeField] protected Material d20;
        [SerializeField] protected Material d12;
        [SerializeField] protected Material d10;
        [SerializeField] protected Material d8;
        [SerializeField] protected Material d6;
        [SerializeField] protected Material d4;

        public Material D20 => d20;
        public Material D12 => d12;
        public Material D10 => d10;
        public Material D8 => d8;
        public Material D6 => d6;
        public Material D4 => d4;

        public Material GetDiceMaterial(DiceType type)
        {
            return type switch
            {
                DiceType.D20 => D20,
                DiceType.D12 => D12,
                DiceType.D10 => D10,
                DiceType.D8 => D8,
                DiceType.D6 => D6,
                DiceType.D4 => D4,
                _ => null
            };
        }
    }
}