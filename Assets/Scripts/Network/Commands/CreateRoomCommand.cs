namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class CreateRoomCommand : ICommand<CreateRoomRequestedEvent>
    {
        [Inject] protected INetworkService NetworkService;
        [Inject] protected NetworkModel Model;
        
        public void Execute(CreateRoomRequestedEvent eventData)
        {
            Model.RoomName = eventData.Name;
            NetworkService.CreateRoom(Model.RoomName);
        }
    }
}