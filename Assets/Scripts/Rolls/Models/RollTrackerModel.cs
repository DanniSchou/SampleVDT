namespace Foxes.Game.Rolls.Models
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Network;
    using UnityEngine;

    [PublicAPI]
    public class RollTrackerModel
    {
        private static float BatchTimeout = 1f;
        
        public event Action<RollTrackerModel> Completed;
        
        protected readonly List<DiceRollModel> DiceRolls;
        
        private float _timeClosed;
        private int _completedRolls;

        public int Count => DiceRolls.Count;

        public bool IsOpen => Time.realtimeSinceStartup < _timeClosed && (Count == 0 || _completedRolls < Count);
        
        public int Modifier { get; set; }
        public string Name { get; set; }
        
        public string Description { get; protected set; }
        public string Roll { get; protected set; }
        public int Result { get; protected set; }

        public RollTrackerModel()
        {
            DiceRolls = new List<DiceRollModel>();
            UpdateTimeClosed();
        }

        private void UpdateTimeClosed()
        {
            _timeClosed = Time.realtimeSinceStartup + BatchTimeout;
        }

        public DiceRollModel AddDice(DiceType type)
        {
            UpdateTimeClosed();
            
            var roll = new DiceRollModel(type);
            roll.Completed += OnRollCompleted;
            DiceRolls.Add(roll);
            return roll;
        }

        public string CreateMessageText(PlayerModel player)
        {
            return string.IsNullOrEmpty(Name) ? 
                $"<b>{player.Name}</b> ({Description})\n{Roll} = {Result}" : 
                $"<b>{player.Name}</b> {Name} ({Description})\n{Roll} = {Result}";
        }

        protected virtual void GenerateResult()
        {
            var prevSideCount = 0;
            var sameSideCount = 0;
            Result = 0;
            Roll = "(";
            Description = string.Empty;

            foreach (var result in DiceRolls)
            {
                var currentSideCount = (int) result.DiceType;
                if (prevSideCount == currentSideCount)
                {
                    sameSideCount++;
                }
                else if (prevSideCount > 0)
                {
                    if (Description.Length > 0) Description += "+";
                    Description += (1 + sameSideCount) + "d" + prevSideCount;
                    sameSideCount = 0;
                }

                prevSideCount = currentSideCount;
                
                if (Roll.Length > 1) Roll += "+";
                Roll += result.Result;
                Result += result.Result;
            }
            
            if (Description.Length > 0) Description += "+";
            Description += (1 + sameSideCount) + "d" + prevSideCount;
            
            Roll += ")";
            
            if (Modifier == 0) return;
            
            var addModifier = Modifier >= 0 ? $"+{Modifier}" : Modifier.ToString();
            Description += addModifier;
            Roll += addModifier;
            Result = Mathf.Max(Result + Modifier, 0);
        }

        private void OnRollCompleted(DiceRollModel diceRollModel)
        {
            diceRollModel.Completed -= OnRollCompleted;

            _completedRolls++;
            if (_completedRolls < Count) return;
            
            GenerateResult();
            Completed?.Invoke(this);
        }
    }
}