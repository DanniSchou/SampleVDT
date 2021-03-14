namespace Foxes.Game.Presets.Presenters
{
    using Core;
    using Models.Actors;
    using Network;
    using Network.Events;
    using Rolls;
    using Rolls.Events;
    using TMPro;
    using UnityEngine;

    public class PresetSpellDamagePresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected PlayerModel PlayerModel;
        
        [SerializeField]
        protected TMP_Text levelTextField;
        
        [SerializeField]
        protected TMP_Text damageTextField;

        [SerializeField] 
        protected GameObject criticalButton;

        private string _actorName;
        private string _spellName;
        private SpellDamage _spellDamage;
        private int _damageModifier;
        
        public void SetSpellDamage(string actorName, string spellName, SpellDamage spellDamage, int damageModifier, bool showCritical)
        {
            _actorName = actorName;
            _spellName = spellName;
            _spellDamage = spellDamage;
            _damageModifier = damageModifier;
            
            UpdateLevelText();
            UpdateDamageText();
            ShowCritical(showCritical);
        }

        private void ShowCritical(bool showCritical)
        {
            criticalButton.SetActive(showCritical);
        }

        private void UpdateLevelText()
        {
            levelTextField.text = _spellDamage.GetLevelText();
        }

        private void UpdateDamageText()
            {
                if (_damageModifier == 0 || _spellDamage.Damage.UseFixedValue)
                {
                    damageTextField.text = _spellDamage.Damage.Name;
                }
                else if (_damageModifier > 0)
                {
                    damageTextField.text = $"{_spellDamage.Damage.Name}+{_damageModifier}";
                }
                else
                {
                    damageTextField.text = $"{_spellDamage.Damage.Name}{_damageModifier}";
                }
                
            }

        private string GetRollName()
        {
            return $"<i>{_actorName}</i> {_spellName}";
        }

        public void RollDamage()
            {
                if (_spellDamage.Damage.UseFixedValue)
                {
                    UseFixedDamage();
                    return;
                }
                
                EventBus.Publish(new RollDiceRequestedEvent((DiceType) _spellDamage.Damage.Value,_spellDamage.Damage.Count, _damageModifier, GetRollName()));
            }

        public void RollCritical()
            {
                if (_spellDamage.Damage.UseFixedValue)
                {
                    UseFixedDamage();
                    return;
                }
                
                EventBus.Publish(new RollDiceRequestedEvent((DiceType) _spellDamage.Damage.Value,_spellDamage.Damage.Count * 2, _damageModifier, GetRollName() + " (Critical)"));
            }
    
            private void UseFixedDamage()
            {
                var message = $"<b>{PlayerModel.Name}</b> {_spellName} ({_spellDamage.Damage.Name})\n{_spellDamage.Damage.FixedValue} = {_spellDamage.Damage.FixedValue}";
                EventBus.Publish(new SendMessageRequestEvent(message, PlayerModel.Color));
            }
    }
}