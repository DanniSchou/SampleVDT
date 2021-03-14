namespace Foxes.Game.Rolls.Models
{
    using System;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class CurrentRollsModel
    {
        public event Action<CurrentRollsModel, RollTrackerModel> TrackerCompleted;
        public event Action<CurrentRollsModel, RollTrackerModel, DiceRollModel> RollDice;
        
        private RollTrackerModel _latestTracker;

        public void AddDice(DiceType type, int count)
        {
            for (var i = 0; i < count; i++)
            {
                AddDice(type);
            }
        }

        public void AddDice(DiceType type)
        {
            if (_latestTracker == null || !_latestTracker.IsOpen)
            {
                BeginTracking();
            }

            var diceRoll = _latestTracker.AddDice(type);
            RollDice?.Invoke(this, _latestTracker, diceRoll);
        }
        
        public void BeginTracking(RollTrackerModel tracker = null)
        {
            if (_latestTracker != null)
            {
                EndTracking();
            }

            _latestTracker = tracker ?? new RollTrackerModel();
            _latestTracker.Completed += OnTrackerCompleted;
        }

        public void EndTracking()
        {
            if (_latestTracker.Count == 0)
            {
                RemoveTrackerEvents(_latestTracker);
            }

            _latestTracker = null;
        }

        private void RemoveTrackerEvents(RollTrackerModel tracker)
        {
            tracker.Completed -= OnTrackerCompleted;
        }

        private void OnTrackerCompleted(RollTrackerModel tracker)
        {
            RemoveTrackerEvents(tracker);
            TrackerCompleted?.Invoke(this, tracker);
        }
    }
}