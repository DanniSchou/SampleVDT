namespace Foxes.Game.Presets.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class FetchMonsterCommand : ICommand<AddMonsterRequestedEvent>
    {
        [Inject] protected IPresetService PresetService;
        
        public void Execute(AddMonsterRequestedEvent eventData)
        {
            PresetService.LoadMonster(eventData.Id);
        }
    }
}