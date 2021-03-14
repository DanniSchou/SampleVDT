namespace Foxes.Game.Rolls.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class AddDiceCommand : ICommand<AddDiceRequestedEvent>
    {
        [Inject] protected CurrentRollsModel CurrentRollsModel;
        
        public void Execute(AddDiceRequestedEvent eventData)
        {
            CurrentRollsModel.AddDice(eventData.Dice);
        }
    }
}