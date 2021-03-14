namespace Foxes.Game.Themes.Models
{
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu]
    public class DiceSkinCollection : ScriptableObject
    {
        [SerializeField] protected DiceSkin[] diceSkins;

        public int Count => diceSkins.Length;

        public DiceSkin GetDiceSkin(int index)
        {
            return diceSkins[index];
        }
        
        public DiceSkin GetDiceSkin(string skinName)
        {
            return diceSkins.FirstOrDefault(skin => Equals(skin.name, skinName));
        }
    }
}