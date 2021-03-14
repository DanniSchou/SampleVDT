namespace Foxes.Game.Network.Events
{
    using Core;
    using JetBrains.Annotations;

    [PublicAPI]
    public readonly struct DisconnectedEvent : IEvent
    {
        public string Cause { get; }
        
        public DisconnectedEvent(string cause)
        {
            Cause = cause;
        }
    }
}