namespace Foxes.Game.Network.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class SendMessageCommand : ICommand<SendMessageRequestEvent>
    {
        [Inject] protected INetworkMessageService MessageService;
        
        public void Execute(SendMessageRequestEvent eventData)
        {
            MessageService.SendMessage(eventData.Message, eventData.Color);
        }
    }
}