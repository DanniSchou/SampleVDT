namespace Foxes.Game.Messages
{
    using JetBrains.Annotations;
    using UnityEngine;

    [PublicAPI]
    public class MessageModel
    {
        public string Text { get; }
        public Color Color { get; }
        public float TimeCreated { get; }

        public MessageModel(string text, Color color)
        {
            Text = text;
            Color = color;
            TimeCreated = Time.realtimeSinceStartup;
        }
    }
}