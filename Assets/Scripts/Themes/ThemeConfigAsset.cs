namespace Foxes.Game.Themes
{
    using Commands;
    using Core;
    using Events;
    using Models;
    using UnityEngine;

    public class ThemeConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        
        [Inject] protected ICommandMap CommandMap;

        [SerializeField] protected ThemeCollection themes;
        [SerializeField] protected DiceSkinCollection diceSkins;

        public override void Configure()
        {
            Injector.Bind<ThemeCollection>().ToValue(themes);
            Injector.Bind<DiceSkinCollection>().ToValue(diceSkins);
            
            Injector.Bind<ThemeModel>().AsSingle();
            Injector.Bind<DiceSkinModel>().AsSingle();
            
            CommandMap.Map<CycleThemeRequestedEvent, CycleThemeCommand>();
            CommandMap.Map<CycleDiceSkinRequestedEvent, CycleDiceSkinCommand>();
        }
    }
}