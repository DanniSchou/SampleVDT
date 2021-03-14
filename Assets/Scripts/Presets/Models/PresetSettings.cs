namespace Foxes.Game.Presets.Models
{
    using UnityEngine;

    [CreateAssetMenu]
    public class PresetSettings : ScriptableObject
    {
        [SerializeField] 
        protected string characterBaseUrl;
        
        [SerializeField] 
        protected string characterWebBaseUrl;

        [SerializeField] 
        protected string monsterBaseUrl;
        
        [SerializeField] 
        protected string monsterWebBaseUrl;

        public string CharacterBaseUrl => characterBaseUrl;
        public string CharacterWebBaseUrl => characterWebBaseUrl;
        public string MonsterBaseUrl => monsterBaseUrl;
        public string MonsterWebBaseUrl => monsterWebBaseUrl;
    }
}