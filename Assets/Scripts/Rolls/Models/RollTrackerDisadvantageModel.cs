namespace Foxes.Game.Rolls.Models
{
    public class RollTrackerDisadvantageModel : RollTrackerModel
    {
        protected override void GenerateResult()
        {
            var addModifier = Modifier >= 0 ? $"+{Modifier}" : Modifier.ToString();
            Description = $"2d20kl1{addModifier}";

            var lowestValue = 20;
            Roll = "(";
            foreach (var diceRoll in DiceRolls)
            {
                if (Roll.Length > 1) Roll += ",";
                if (lowestValue > diceRoll.Result) lowestValue = diceRoll.Result;
                Roll += diceRoll.Result;
            }
            
            Roll += $"){addModifier}";
            Result = lowestValue + Modifier;
        }
    }
}