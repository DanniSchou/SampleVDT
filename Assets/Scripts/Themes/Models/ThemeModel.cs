namespace Foxes.Game.Themes.Models
{
    using System;
    using Core;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ThemeModel
    {
        [Inject] protected ThemeCollection Themes;
        
        public event Action<ThemeModel> ThemeChanged;
        
        private int _themeIndex = -1;
        private Theme _currentTheme;
        
        public Theme Theme => _currentTheme;

        public void CycleTheme()
        {
            _themeIndex = (_themeIndex + 1) % Themes.Count;
            _currentTheme = Themes.GetTheme(_themeIndex);
            ThemeChanged?.Invoke(this);
        }
    }
}