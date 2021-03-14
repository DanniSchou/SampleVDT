namespace Foxes.Game.Externals.Samples
{
    using Core;
    using Messages;
    using Network;
    using UnityEngine;

    public class SampleMessageService : INetworkMessageService
    {
        [Inject] protected IEventBus EventBus;
        
        public void SendMessage(string message, Color color)
        {
            EventBus.Publish(new MessageSubmittedEvent(message, color));
        }
    }
}