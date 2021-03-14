namespace Foxes.Game.Presets
{
    using Commands;
    using Core;
    using Events;
    using Models;

    public class PresetConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        [Inject] protected ICommandMap CommandMap;
        
        public override void Configure()
        {
            Injector.Bind<PresetModel>().AsSingle();
            
            CommandMap.Map<AddCharacterRequestedEvent,FetchCharacterCommand>();
            CommandMap.Map<AddMonsterRequestedEvent,FetchMonsterCommand>();
            CommandMap.Map<ActorLoadedEvent,AddLoadedActorCommand>();
            CommandMap.Map<RemovePresetRequestedEvent,RemovePresetCommand>();
        }
    }
}