namespace Foxes.Game.Themes.Commands
{
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Models;

    [UsedImplicitly]
    public class CycleDiceSkinCommand : ICommand<CycleDiceSkinRequestedEvent>
    {
        [Inject] protected DiceSkinModel DiceSkinModel;
        
        public void Execute(CycleDiceSkinRequestedEvent eventData)
        {
            DiceSkinModel.CycleSkin();
        }
    }
}