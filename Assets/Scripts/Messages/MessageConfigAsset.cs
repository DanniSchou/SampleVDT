namespace Foxes.Game.Messages
{
    using Core;
    using UnityEngine;

    public class MessageConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        
        [Inject] protected ICommandMap CommandMap;

        [SerializeField] protected MessageSettings settings;

        public override void Configure()
        {
            Injector.Bind<MessageSettings>().ToValue(settings);
            Injector.Bind<MessageListModel>().AsSingle();
            
            CommandMap.Map<MessageSubmittedEvent, AddMessageCommand>();
        }
    }
}