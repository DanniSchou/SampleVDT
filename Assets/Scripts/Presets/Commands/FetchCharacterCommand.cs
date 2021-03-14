namespace Foxes.Game.Presets.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class FetchCharacterCommand : ICommand<AddCharacterRequestedEvent>
    {
        [Inject] protected IPresetService PresetService;
        
        public void Execute(AddCharacterRequestedEvent eventData)
        {
            PresetService.LoadCharacter(eventData.Id);
        }
    }
}