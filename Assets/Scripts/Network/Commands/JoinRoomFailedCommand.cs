namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class JoinRoomFailedCommand : ICommand<CreateRoomFailedEvent>, ICommand<JoinRoomFailedEvent>
    {
        [Inject] protected NetworkModel Model;
        
        public void Execute(CreateRoomFailedEvent eventData)
        {
            InvalidateRoomName();
        }

        public void Execute(JoinRoomFailedEvent eventData)
        {
            InvalidateRoomName();
        }

        private void InvalidateRoomName()
        {
            Model.RoomName = null;
        }
    }
}