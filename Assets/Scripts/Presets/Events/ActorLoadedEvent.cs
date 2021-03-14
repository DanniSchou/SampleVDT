namespace Foxes.Game.Presets.Events
{
    using Core;
    using Models.Actors;

    public readonly struct ActorLoadedEvent : IEvent
    {
        public IPresetActor PresetActor { get; }
        
        public ActorLoadedEvent(IPresetActor presetActor)
        {
            PresetActor = presetActor;
        }
    }
}