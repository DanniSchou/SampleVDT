namespace Foxes.Game.Rolls.Models
{
    using System;
    using JetBrains.Annotations;

    [PublicAPI]
    public class DiceRollModel
    {
        public event Action<DiceRollModel> Completed; 
        
        public DiceType DiceType { get; }
        public bool IsCompleted { get; private set; }

        private int _result;

        public int Result
        {
            get => _result;
            set
            {
                _result = value;
                IsCompleted = true;
            
                Completed?.Invoke(this);
            }
        }

        public DiceRollModel(DiceType type)
        {
            DiceType = type;
        }
    }
}