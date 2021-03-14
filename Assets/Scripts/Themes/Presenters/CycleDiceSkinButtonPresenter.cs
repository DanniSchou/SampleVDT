namespace Foxes.Game.Themes.Presenters
{
    using Core;
    using Events;
    using Models;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CycleDiceSkinButtonPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected DiceSkinModel DiceSkinModel;

        [SerializeField] protected Button button;
        [SerializeField] protected TMP_Text text;
        
        protected override void Start()
        {
            base.Start();

            button.onClick.AddListener(OnClick);
            DiceSkinModel.DiceSkinChanged += OnDiceSkinChanged;

            UpdateSkin();
        }

        private void UpdateSkin()
        {
            if (DiceSkinModel.DiceSkin != null)
            {
                OnDiceSkinChanged(DiceSkinModel);
            }
            else
            {
                OnClick();
            }
        }

        protected void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
            DiceSkinModel.DiceSkinChanged -= OnDiceSkinChanged;
        }

        private void OnDiceSkinChanged(DiceSkinModel model)
        {
            text.text = $"Dice: {model.DiceSkin.name}";
        }

        private void OnClick()
        {
            EventBus.Publish(new CycleDiceSkinRequestedEvent());
        }
    }
}