namespace Foxes.Game
{
    using Core;
    using Network.Events;
    using Rolls;
    using UnityEngine;

    public class GameConfigAsset : ConfigAsset
    {
        [Inject] protected IEventBus EventBus;

        [Inject] protected RollCommandController RollCommandController;
        
        public override void Configure()
        {
            // initialize game
            
            Screen.SetResolution(800, 600, FullScreenMode.Windowed);
            
            RollCommandController.Initialize();
            EventBus.Publish(new JoinLobbyRequestedEvent());
        }
    }
}
