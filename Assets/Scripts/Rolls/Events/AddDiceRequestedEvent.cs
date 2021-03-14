namespace Foxes.Game.Rolls.Events
{
    using Core;

    public readonly struct AddDiceRequestedEvent : IEvent
    {
        public DiceType Dice { get; }

        public AddDiceRequestedEvent(DiceType dice)
        {
            Dice = dice;
        }
    }
}