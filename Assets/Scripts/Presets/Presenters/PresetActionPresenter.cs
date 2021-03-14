namespace Foxes.Game.Presets.Presenters
{
    using Models.Actors;
    using Network.Events;
    using Rolls;
    using Rolls.Events;
    using TMPro;
    using UnityEngine;

    public class PresetActionPresenter : PresetCheckPresenter
    {
        [SerializeField] 
        protected GameObject buttonGroup;
        
        [SerializeField]
        protected TMP_Text damageTextField;

        protected CombatModel CombatModel;

        public override void SetModel(CheckModel model)
        {
            CombatModel = (CombatModel) model;
            base.SetModel(model);

            UpdateDamageText();
            UpdateCheckButtonGroup(CombatModel.CombatAction.HasAttack());
        }

        protected override void UpdateText()
        {
            if (CombatModel.CombatAction.HasAttack())
            {
                base.UpdateText();
            }
            else
            {
                nameTextField.text = CombatModel.CheckName;
            }
        }

        private void UpdateCheckButtonGroup(bool showGroup)
        {
            if (buttonGroup.activeSelf != showGroup) buttonGroup.SetActive(showGroup);
        }

        private void UpdateDamageText()
        {
            if (CombatModel.DamageModifier == 0 || CombatModel.CombatAction.Damage.UseFixedValue)
            {
                damageTextField.text = CombatModel.CombatAction.Damage.Name;
            }
            else if (CombatModel.DamageModifier > 0)
            {
                damageTextField.text = $"{CombatModel.CombatAction.Damage.Name}+{CombatModel.DamageModifier}";
            }
            else
            {
                damageTextField.text = $"{CombatModel.CombatAction.Damage.Name}{CombatModel.DamageModifier}";
            }
        }

        public void RollDamage()
        {
            if (CombatModel.CombatAction.Damage.UseFixedValue)
            {
                UseFixedDamage();
                return;
            }
            
            EventBus.Publish(new RollDiceRequestedEvent((DiceType) CombatModel.CombatAction.Damage.Value, CombatModel.CombatAction.Damage.Count, CombatModel.DamageModifier, GetRollName()));
        }

        public void RollCritical()
        {
            if (CombatModel.CombatAction.Damage.UseFixedValue)
            {
                UseFixedDamage();
                return;
            }
            
            EventBus.Publish(new RollDiceRequestedEvent((DiceType) CombatModel.CombatAction.Damage.Value, CombatModel.CombatAction.Damage.Count * 2, CombatModel.DamageModifier, GetRollName() + " (Critical)"));
        }

        private void UseFixedDamage()
        {
            var message = $"<b>{PlayerModel.Name}</b> {CombatModel.CheckName} ({CombatModel.CombatAction.Damage.Name})\n{CombatModel.CombatAction.Damage.FixedValue} = {CombatModel.CombatAction.Damage.FixedValue}";
            EventBus.Publish(new SendMessageRequestEvent(message, PlayerModel.Color));
        }
    }
}
