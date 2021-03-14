namespace Foxes.Game.Rolls.Presenters
{
    using Models;

    public interface IDiePresenter
    {
        void Roll(DiceRollModel diceRoll);
    }
}