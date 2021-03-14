namespace Foxes.Game.Rolls.Events
{
    using Core;

    public readonly struct RollDisadvantageRequestedEvent : IEvent
    {
        public int Modifier { get; }
        public string Name { get; }

        public RollDisadvantageRequestedEvent(int modifier = 0, string name = null)
        {
            Modifier = modifier;
            Name = name;
        }
    }
}