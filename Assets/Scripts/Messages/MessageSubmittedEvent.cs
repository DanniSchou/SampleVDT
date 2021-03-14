namespace Foxes.Game.Messages
{
    using Core;
    using UnityEngine;

    public readonly struct MessageSubmittedEvent : IEvent
    {
        public string Text { get; }
        public Color Color { get; }
        
        public MessageSubmittedEvent(string text, Color color)
        {
            Text = text;
            Color = color;
        }
    }
}