namespace Foxes.Game.Themes.Presenters
{
    using Core;
    using Events;
    using Models;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CycleThemeButtonPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected ThemeModel ThemeModel;

        [SerializeField] protected Button button;
        [SerializeField] protected TMP_Text text;
        
        protected override void Start()
        {
            base.Start();

            button.onClick.AddListener(OnClick);
            ThemeModel.ThemeChanged += OnThemeChanged;

            UpdateTheme();
        }

        private void UpdateTheme()
        {
            if (ThemeModel.Theme != null)
            {
                OnThemeChanged(ThemeModel);
            }
            else
            {
                OnClick();
            }
        }

        protected void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
            ThemeModel.ThemeChanged -= OnThemeChanged;
        }

        private void OnThemeChanged(ThemeModel model)
        {
            text.text = $"Theme: {model.Theme.name}";
        }

        private void OnClick()
        {
            EventBus.Publish(new CycleThemeRequestedEvent());
        }
    }
}