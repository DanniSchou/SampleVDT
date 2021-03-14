namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class JoinRoomCommand : ICommand<JoinRoomRequestedEvent>
    {
        [Inject] protected INetworkService NetworkService;
        [Inject] protected NetworkModel Model;
        
        public void Execute(JoinRoomRequestedEvent eventData)
        {
            Model.RoomName = eventData.Name;
            NetworkService.JoinRoom(Model.RoomName);
        }
    }
}