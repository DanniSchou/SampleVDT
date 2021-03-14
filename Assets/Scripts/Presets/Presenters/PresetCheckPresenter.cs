namespace Foxes.Game.Presets.Presenters
{
    using Core;
    using Models.Actors;
    using Network;
    using Rolls;
    using Rolls.Events;
    using TMPro;
    using UnityEngine;

    public class PresetCheckPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected PlayerModel PlayerModel;
        
        [SerializeField]
        protected TMP_Text nameTextField;

        protected CheckModel Model;

        public virtual void SetModel(CheckModel model)
        {
            Model = model;

            UpdateText();
        }

        protected virtual void UpdateText()
        {
            nameTextField.text = $"{Model.CheckName} ({(Model.CheckModifier >= 0 ? "+" : string.Empty)}{Model.CheckModifier})";
        }
        
        protected string GetRollName()
        {
            return $"<i>{Model.ActorName}</i> {Model.CheckName}";
        }

        public void RollCheck()
        {
            EventBus.Publish(new RollDiceRequestedEvent(DiceType.D20, 1, Model.CheckModifier, GetRollName()));
        }

        public void RollCheckAdvantage()
        {
            EventBus.Publish(new RollAdvantageRequestedEvent(Model.CheckModifier, GetRollName()));
        }

        public void RollCheckDisadvantage()
        {
            EventBus.Publish(new RollDisadvantageRequestedEvent(Model.CheckModifier, GetRollName()));
        }
    }
}
