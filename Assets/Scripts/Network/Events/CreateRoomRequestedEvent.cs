namespace Foxes.Game.Network.Events
{
    using Core;

    public readonly struct CreateRoomRequestedEvent : IEvent
    {
        public string Name { get; }
        
        public CreateRoomRequestedEvent(string name)
        {
            Name = name;
        }
    }
}