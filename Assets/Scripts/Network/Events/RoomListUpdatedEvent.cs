namespace Foxes.Game.Network.Events
{
    using Core;

    public readonly struct RoomListUpdatedEvent : IEvent
    {
        public string[] RoomList { get; }
        
        public RoomListUpdatedEvent(string[] roomList)
        {
            RoomList = roomList;
        }
    }
}