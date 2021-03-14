namespace Foxes.Game.Externals.Samples
{
    using System.Collections;
    using Core;
    using Rolls.Models;
    using Rolls.Presenters;
    using UnityEngine;

    public class SampleDicePresenter : InjectedBehaviour, IDiePresenter
    {
        private DiceRollModel _model;
        
        public void Roll(DiceRollModel diceRoll)
        {
            _model = diceRoll;
            
            // trigger rolling the dice preferably in a view class
            // use events to get dice results when it's done rolling

            StartCoroutine(MockRoll());
        }

        private IEnumerator MockRoll()
        {
            yield return new WaitForSeconds(1f);
            
            var sideCount = (int) _model.DiceType;
            var result = Random.Range(1, sideCount + 1);
            OnResult(result);
        }

        private void OnResult(int value)
        {
            _model.Result = value;
        }
    }
}