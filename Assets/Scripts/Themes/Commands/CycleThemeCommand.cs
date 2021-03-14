namespace Foxes.Game.Themes.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class CycleThemeCommand : ICommand<CycleThemeRequestedEvent>
    {
        [Inject] protected ThemeModel ThemeModel;
        
        public void Execute(CycleThemeRequestedEvent eventData)
        {
            ThemeModel.CycleTheme();
        }
    }
}