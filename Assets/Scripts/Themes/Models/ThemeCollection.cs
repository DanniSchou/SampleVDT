namespace Foxes.Game.Themes.Models
{
    using UnityEngine;

    [CreateAssetMenu]
    public class ThemeCollection : ScriptableObject
    {
        [SerializeField] protected Theme[] themes;

        public int Count => themes.Length;

        public Theme GetTheme(int index)
        {
            return themes[index];
        }
    }
}