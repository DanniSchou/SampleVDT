namespace Foxes.Game.Externals.Samples
{
    using Core;
    using Network;
    using Network.Events;

    /// <summary>
    /// The SampleNetworkService doesn't create any network connection but just allows
    /// the application to continue by pretending the user joined a room.
    /// </summary>
    public class SampleNetworkService : INetworkService
    {
        [Inject] protected IEventBus EventBus;
        
        public void JoinLobby()
        {
        }

        public void CreateRoom(string room)
        {
            EventBus.Publish(new JoinedRoomEvent());
        }

        public void JoinRoom(string room)
        {
            EventBus.Publish(new JoinedRoomEvent());
        }
    }
}