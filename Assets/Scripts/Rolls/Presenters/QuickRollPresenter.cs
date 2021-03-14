namespace Foxes.Game.Rolls.Presenters
{
    using Core;
    using Events;
    using UnityEngine;

    public class QuickRollPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;

        [SerializeField] protected DiceType dice = DiceType.D20;

        protected void OnMouseUp()
        {
            EventBus.Publish(new AddDiceRequestedEvent(dice));
        }
    }
}
