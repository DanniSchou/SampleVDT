namespace Foxes.Game.Presets.Events
{
    using Core;

    public readonly struct AddCharacterRequestedEvent : IEvent
    {
        public string Id { get; }

        public AddCharacterRequestedEvent(string id)
        {
            Id = id;
        }
    }
}