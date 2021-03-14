namespace Foxes.Game.Network.Events
{
    using Core;

    public readonly struct PlayerLeftRoomEvent : IEvent
    {
        public INetworkPlayer Player { get; }
        
        public PlayerLeftRoomEvent(INetworkPlayer player)
        {
            Player = player;
        }
    }
}