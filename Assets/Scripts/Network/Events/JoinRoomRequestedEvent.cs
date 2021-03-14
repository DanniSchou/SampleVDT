namespace Foxes.Game.Network.Events
{
    using Core;

    public readonly struct JoinRoomRequestedEvent : IEvent
    {
        public string Name { get; }
        
        public JoinRoomRequestedEvent(string name)
        {
            Name = name;
        }
    }
}