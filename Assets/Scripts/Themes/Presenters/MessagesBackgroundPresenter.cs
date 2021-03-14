namespace Foxes.Game.Themes.Presenters
{
    using Core;
    using Models;
    using UnityEngine;
    using UnityEngine.UI;

    public class MessagesBackgroundPresenter : InjectedBehaviour
    {
        [Inject] protected ThemeModel ThemeModel;

        [SerializeField] protected Graphic graphic;

        protected override void Start()
        {
            base.Start();

            ThemeModel.ThemeChanged += OnThemeChanged;
            
            if (ThemeModel.Theme != null)
            {
                OnThemeChanged(ThemeModel);
            }
        }

        protected void OnDestroy()
        {
            ThemeModel.ThemeChanged -= OnThemeChanged;
        }

        private void OnThemeChanged(ThemeModel model)
        {
            graphic.enabled = model.Theme.ShowMessagesBackground;
        }
    }
}