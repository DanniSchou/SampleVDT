namespace Foxes.Game.Messages
{
    using Core;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class AddMessageCommand : ICommand<MessageSubmittedEvent>
    {
        [Inject] protected MessageListModel ListModel;
        
        public void Execute(MessageSubmittedEvent eventData)
        {
            var messageModel = new MessageModel(eventData.Text, eventData.Color);
            ListModel.AddMessage(messageModel);
        }
    }
}