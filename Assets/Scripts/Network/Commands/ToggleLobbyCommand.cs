namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ToggleLobbyCommand : ICommand<JoinedRoomEvent>, ICommand<LeftRoomEvent>
    {
        [Inject] private NetworkModel _networkModel;

        public void Execute(JoinedRoomEvent eventData)
        {
            _networkModel.IsConnectedToRoom = true;
        }

        public void Execute(LeftRoomEvent eventData)
        {
            _networkModel.IsConnectedToRoom = false;
        }
    }
}