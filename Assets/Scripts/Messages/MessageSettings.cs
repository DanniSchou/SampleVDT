namespace Foxes.Game.Messages
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Message Settings", menuName = "Foxes/Games/Message Settings")]
    public class MessageSettings : ScriptableObject
    {
        [SerializeField] protected float lifetime = 60f;
        [SerializeField] protected float transitionSpeed = 1f;

        public float Lifetime => lifetime;
        public float TransitionSpeed => transitionSpeed;
    }
}