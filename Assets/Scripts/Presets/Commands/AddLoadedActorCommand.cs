namespace Foxes.Game.Presets.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class AddLoadedActorCommand : ICommand<ActorLoadedEvent>
    {
        [Inject] protected PresetModel PresetModel;
        
        public void Execute(ActorLoadedEvent eventData)
        {
            PresetModel.Add(eventData.PresetActor);
        }
    }
}