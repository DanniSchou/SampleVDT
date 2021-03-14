namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class JoinLobbyCommand : ICommand<JoinLobbyRequestedEvent>
    {
        [Inject] protected INetworkService Service;
        
        public void Execute(JoinLobbyRequestedEvent eventData)
        {
            Service.JoinLobby();
        }
    }
}