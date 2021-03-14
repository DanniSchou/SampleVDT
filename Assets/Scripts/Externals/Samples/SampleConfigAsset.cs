namespace Foxes.Game.Externals.Samples
{
    using Core;
    using Network;
    using Presets;
    using UnityEngine;

    [CreateAssetMenu]
    public class SampleConfigAsset : ConfigAsset
    {
        [Inject] protected IInjector Injector;
        
        public override void Configure()
        {
            Injector.Bind<INetworkService>().ToSingle<SampleNetworkService>();
            Injector.Bind<INetworkObjectFactory>().ToSingle<SampleObjectFactory>();
            Injector.Bind<INetworkMessageService>().ToSingle<SampleMessageService>();
            Injector.Bind<IPresetService>().ToSingle<SamplePresetService>();
        }
    }
}