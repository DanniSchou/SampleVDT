namespace Foxes.Game.Network.Events
{
    using Core;

    public readonly struct PlayerEnteredRoomEvent : IEvent
    {
        public INetworkPlayer Player { get; }
        
        public PlayerEnteredRoomEvent(INetworkPlayer player)
        {
            Player = player;
        }
    }
}