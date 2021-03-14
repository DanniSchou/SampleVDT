namespace Foxes.Game.Rolls.Events
{
    using Core;

    public readonly struct RollAdvantageRequestedEvent : IEvent
    {
        public int Modifier { get; }
        public string Name { get; }

        public RollAdvantageRequestedEvent(int modifier = 0, string name = null)
        {
            Modifier = modifier;
            Name = name;
        }
    }
}