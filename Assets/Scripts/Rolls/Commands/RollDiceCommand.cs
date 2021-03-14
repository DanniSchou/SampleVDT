namespace Foxes.Game.Rolls.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class RollDiceCommand : ICommand<RollDiceRequestedEvent>
    {
        [Inject] protected CurrentRollsModel CurrentRollsModel;

        public void Execute(RollDiceRequestedEvent eventData)
        {
            CurrentRollsModel.BeginTracking(new RollTrackerModel{Modifier = eventData.Modifier, Name = eventData.Name});
            CurrentRollsModel.AddDice(eventData.Dice, eventData.Count);
            CurrentRollsModel.EndTracking();
        }
    }
}