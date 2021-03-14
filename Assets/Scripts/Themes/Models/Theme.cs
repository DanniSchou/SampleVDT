namespace Foxes.Game.Themes.Models
{
    using UnityEngine;

    [CreateAssetMenu]
    public class Theme : ScriptableObject
    {
        [SerializeField] protected Material backgroundMaterial;
        [SerializeField] protected bool showMessagesBackground = true;

        public Material BackgroundMaterial => backgroundMaterial;

        public bool ShowMessagesBackground => showMessagesBackground;
    }
}