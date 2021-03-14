namespace Foxes.Game.Rolls.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class RollAdvantageCommand : ICommand<RollAdvantageRequestedEvent>
    {
        [Inject] protected CurrentRollsModel CurrentRollsModel;

        public void Execute(RollAdvantageRequestedEvent eventData)
        {
            CurrentRollsModel.BeginTracking(new RollTrackerAdvantageModel {Modifier = eventData.Modifier, Name = eventData.Name});
            CurrentRollsModel.AddDice(DiceType.D20, 2);
            CurrentRollsModel.EndTracking();
        }
    }
}