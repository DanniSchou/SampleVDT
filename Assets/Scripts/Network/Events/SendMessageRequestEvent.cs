namespace Foxes.Game.Network.Events
{
    using Core;
    using JetBrains.Annotations;
    using UnityEngine;

    [PublicAPI]
    public readonly struct SendMessageRequestEvent : IEvent
    {
        public string Message { get; }
        public Color Color { get; }
        
        public SendMessageRequestEvent(string message, Color color)
        {
            Message = message;
            Color = color;
        }
    }
}