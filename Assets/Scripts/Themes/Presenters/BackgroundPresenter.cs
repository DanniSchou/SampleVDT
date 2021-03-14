namespace Foxes.Game.Themes.Presenters
{
    using Core;
    using Models;
    using UnityEngine;

    public class BackgroundPresenter : InjectedBehaviour
    {
        [Inject] protected ThemeModel ThemeModel;

        [SerializeField] protected Renderer target;

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
            var material = model.Theme.BackgroundMaterial;
            target.enabled = material != null;
            target.sharedMaterial = material;
        }
    }
}