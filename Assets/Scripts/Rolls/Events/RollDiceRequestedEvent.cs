namespace Foxes.Game.Rolls.Events
{
    using Core;

    public readonly struct RollDiceRequestedEvent : IEvent
    {
        public DiceType Dice { get; }
        public int Count { get; }
        public int Modifier { get; }
        public string Name { get; }

        public RollDiceRequestedEvent(DiceType dice, int count, int modifier, string name = null)
        {
            Dice = dice;
            Count = count;
            Modifier = modifier;
            Name = name;
        }
    }
}