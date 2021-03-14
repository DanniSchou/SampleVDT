namespace Foxes.Game.Rolls.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class RollDisadvantageCommand : ICommand<RollDisadvantageRequestedEvent>
    {
        [Inject] protected CurrentRollsModel CurrentRollsModel;

        public void Execute(RollDisadvantageRequestedEvent eventData)
        {
            CurrentRollsModel.BeginTracking(new RollTrackerDisadvantageModel() {Modifier = eventData.Modifier, Name = eventData.Name});
            CurrentRollsModel.AddDice(DiceType.D20, 2);
            CurrentRollsModel.EndTracking();
        }
    }
}