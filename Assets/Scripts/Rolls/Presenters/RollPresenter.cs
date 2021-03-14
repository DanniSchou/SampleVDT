namespace Foxes.Game.Rolls.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Models;
    using Network;
    using Network.Events;
    using UnityEngine;

    public class RollPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected PlayerModel PlayerModel;
        [Inject] protected INetworkObjectFactory ObjectFactory;
        [Inject] protected CurrentRollsModel CurrentRollsModel;

        [SerializeField] protected Transform spawnTransform;
        [SerializeField] protected RollDescription[] dicePrefabs;

        private readonly Dictionary<RollTrackerModel, List<GameObject>> _trackerObjects = new Dictionary<RollTrackerModel, List<GameObject>>();
        
        protected override void Start()
        {
            base.Start();

            CurrentRollsModel.RollDice += OnRollDice;
            CurrentRollsModel.TrackerCompleted += OnTrackerCompleted;
        }

        private void OnRollDice(CurrentRollsModel currentRolls, RollTrackerModel rollTracker, DiceRollModel diceRoll)
        {
            var description = dicePrefabs.FirstOrDefault(x => x.Type == diceRoll.DiceType);
            if (description?.Prefab == null) return;

            var diceObject = ObjectFactory.NetworkInstantiate(description.Prefab, spawnTransform.position, spawnTransform.rotation);
            var diePresenter = diceObject.GetComponent<IDiePresenter>();
            if (diePresenter != null)
            {
                if (!_trackerObjects.TryGetValue(rollTracker, out var objects))
                {
                    objects = new List<GameObject>();
                    _trackerObjects.Add(rollTracker, objects);
                }
                
                objects.Add(diceObject);
                diePresenter.Roll(diceRoll);
            }
            else
            {
                ObjectFactory.NetworkDestroy(diceObject);
            }
        }

        private void OnTrackerCompleted(CurrentRollsModel currentRolls, RollTrackerModel rollTracker)
        {
            if (_trackerObjects.TryGetValue(rollTracker, out var objects))
            {
                foreach (var diceObjects in objects)
                {
                    if (diceObjects != null)
                    {
                        ObjectFactory.NetworkDestroy(diceObjects);
                    }
                }
            }

            var message = rollTracker.CreateMessageText(PlayerModel);
            EventBus.Publish(new SendMessageRequestEvent(message, PlayerModel.Color));
        }
        
        [Serializable]
        protected class RollDescription
        {
            public DiceType Type;
            public GameObject Prefab;
        }
    }
}
