namespace Foxes.Game.Rolls
{
    using System;
    using Commands;
    using Core;
    using Events;
    using JetBrains.Annotations;
    using Network;

    [UsedImplicitly]
    public class RollCommandController : IDisposable
    {
        [Inject] protected NetworkModel NetworkModel;
        [Inject] protected ICommandMap CommandMap;

        public void Initialize()
        {
            NetworkModel.IsConnectedToRoomChanged += OnConnectedChanged;
        }
        
        private void OnConnectedChanged(NetworkModel model)
        {
            if (model.IsConnectedToRoom)
            {
                SetUpCommands();
            }
            else
            {
                TearDownCommands();
            }
        }

        private void SetUpCommands()
        {
            CommandMap.Map<AddDiceRequestedEvent, AddDiceCommand>();
            CommandMap.Map<RollDiceRequestedEvent, RollDiceCommand>();
            CommandMap.Map<RollAdvantageRequestedEvent, RollAdvantageCommand>();
            CommandMap.Map<RollDisadvantageRequestedEvent, RollDisadvantageCommand>();
        }
        
        private void TearDownCommands()
        {
            CommandMap.UnMap<AddDiceRequestedEvent, AddDiceCommand>();
            CommandMap.UnMap<RollDiceRequestedEvent, RollDiceCommand>();
            CommandMap.UnMap<RollAdvantageRequestedEvent, RollAdvantageCommand>();
            CommandMap.UnMap<RollDisadvantageRequestedEvent, RollDisadvantageCommand>();
        }

        public void Dispose()
        {
            NetworkModel.IsConnectedToRoomChanged -= OnConnectedChanged;
        }
    }
}