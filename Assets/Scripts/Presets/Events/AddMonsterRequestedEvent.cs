namespace Foxes.Game.Presets.Events
{
    using Core;

    public readonly struct AddMonsterRequestedEvent : IEvent
    {
        public string Id { get; }
        
        public AddMonsterRequestedEvent(string id)
        {
            Id = id;
        }
    }
}