namespace Foxes.Game.Rolls
{
    using Core;
    using Models;

    public class RollConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        
        public override void Configure()
        {
            Injector.Bind<CurrentRollsModel>().AsSingle();
            Injector.Bind<RollCommandController>().AsSingle();
        }
    }
}