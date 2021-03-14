namespace Foxes.Game.Rolls.Models
{
    public class RollTrackerAdvantageModel : RollTrackerModel
    {
        protected override void GenerateResult()
        {
            var addModifier = Modifier >= 0 ? $"+{Modifier}" : Modifier.ToString();
            Description = $"2d20kh1{addModifier}";

            var highestValue = 0;
            Roll = "(";
            foreach (var diceRoll in DiceRolls)
            {
                if (Roll.Length > 1) Roll += ",";
                if (highestValue < diceRoll.Result) highestValue = diceRoll.Result;
                Roll += diceRoll.Result;
            }
            
            Roll += $"){addModifier}";
            Result = highestValue + Modifier;
        }
    }
}