namespace Foxes.Game.Presets.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class RemovePresetCommand : ICommand<RemovePresetRequestedEvent>
    {
        [Inject] protected PresetModel PresetModel;
        
        public void Execute(RemovePresetRequestedEvent eventData)
        {
            var actor = PresetModel.GetFromId(eventData.PresetId);
            if (actor != null)
            {
                PresetModel.Remove(actor);
            }
        }
    }
}