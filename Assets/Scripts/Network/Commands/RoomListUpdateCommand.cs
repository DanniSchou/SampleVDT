namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class RoomListUpdateCommand : ICommand<RoomListUpdatedEvent>
    {
        [Inject] private NetworkModel _networkModel;
        
        public void Execute(RoomListUpdatedEvent eventData)
        {
            _networkModel.RoomList = eventData.RoomList;
        }
    }
}