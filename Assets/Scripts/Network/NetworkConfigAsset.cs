namespace Foxes.Game.Network
{
    using Commands;
    using Core;
    using Events;

    public class NetworkConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        
        [Inject] protected ICommandMap CommandMap;
        
        public override void Configure()
        {
            Injector.Bind<PlayerModel>().AsSingle();
            Injector.Bind<NetworkModel>().AsSingle();

            CommandMap.Map<JoinLobbyRequestedEvent, JoinLobbyCommand>();
            CommandMap.Map<CreateRoomRequestedEvent, CreateRoomCommand>();
            CommandMap.Map<JoinRoomRequestedEvent, JoinRoomCommand>();
            CommandMap.Map<RoomListUpdatedEvent, RoomListUpdateCommand>();
            CommandMap.Map<JoinedRoomEvent, ToggleLobbyCommand>();
            CommandMap.Map<LeftRoomEvent, ToggleLobbyCommand>();
            CommandMap.Map<PlayerEnteredRoomEvent, ShowPlayerChangesCommand>();
            CommandMap.Map<PlayerLeftRoomEvent, ShowPlayerChangesCommand>();
            CommandMap.Map<CreateRoomFailedEvent, JoinRoomFailedCommand>();
            CommandMap.Map<JoinRoomFailedEvent, JoinRoomFailedCommand>();
            CommandMap.Map<SendMessageRequestEvent, SendMessageCommand>();
        }
    }
}