namespace Foxes.Game.Presets.Events
{
    using Core;

    public readonly struct RemovePresetRequestedEvent : IEvent
    {
        public string PresetId { get; }
        
        public RemovePresetRequestedEvent(string presetId)
        {
            PresetId = presetId;
        }
    }
}