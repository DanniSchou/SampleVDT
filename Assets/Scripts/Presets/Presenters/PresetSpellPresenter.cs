namespace Foxes.Game.Presets.Presenters
{
    using Models.Actors;
    using UnityEngine;

    public class PresetSpellPresenter : PresetCheckPresenter
    {
        [SerializeField] 
        protected GameObject spellDamagePrefab;
        
        [SerializeField] 
        protected GameObject buttonGroup;

        protected SpellModel SpellModel;
        
        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        public override void SetModel(CheckModel model)
        {
            SpellModel = (SpellModel) model;
            base.SetModel(model);

            CreateDamageUI(); 
            UpdateCheckButtonGroup(SpellModel.SpellAction.HasAttack());
        }

        protected override void UpdateText()
        {
            if (SpellModel.SpellAction.HasAttack())
            {
                base.UpdateText();
            }
            else
            {
                nameTextField.text = SpellModel.CheckName;
            }
        }

        private void UpdateCheckButtonGroup(bool showGroup)
        {
            if (buttonGroup.activeSelf != showGroup) buttonGroup.SetActive(showGroup);
        }

        private void CreateDamageUI()
        {
            foreach (var damage in SpellModel.SpellAction.Damages)
            {
                var damageObject = Instantiate(spellDamagePrefab, _rectTransform);
                var damageBehaviour = damageObject.GetComponent<PresetSpellDamagePresenter>();
                damageBehaviour.SetSpellDamage(SpellModel.ActorName, $"[{damage.GetLevelText()}] {SpellModel.CheckName}", damage, SpellModel.DamageModifier, SpellModel.SpellAction.HasAttack());
            }
        }
    }
}