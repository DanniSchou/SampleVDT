namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Messages;

    [UsedImplicitly]
    public class ShowPlayerChangesCommand : ICommand<PlayerEnteredRoomEvent>, ICommand<PlayerLeftRoomEvent>
    {
        [Inject] protected IEventBus EventBus;
        
        public void Execute(PlayerEnteredRoomEvent eventData)
        {
            var player = eventData.Player;
            var message = $"{player.Name} joined";
            EventBus.Publish(new MessageSubmittedEvent(message, player.Color));
        }

        public void Execute(PlayerLeftRoomEvent eventData)
        {
            var player = eventData.Player;
            var message = $"{player.Name} left";
            EventBus.Publish(new MessageSubmittedEvent(message, player.Color));
        }

        
    }
}