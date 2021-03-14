namespace Foxes.Game.Presets.Models.Actors
{
    public static class ActorHelper
    {
        public static int ScoreToModifier(int score)
        {
            var movedScore = score - 10;
            if (movedScore < 0) movedScore--;
            return movedScore / 2;
        }

        public static CheckType GetSaveFromAbility(Ability ability)
        {
            return ability switch
            {
                Ability.Strength => CheckType.SaveStrength,
                Ability.Dexterity => CheckType.SaveDexterity,
                Ability.Constitution => CheckType.SaveConstitution,
                Ability.Intelligence => CheckType.SaveIntelligence,
                Ability.Wisdom => CheckType.SaveWisdom,
                Ability.Charisma => CheckType.SaveCharisma,
                _ => CheckType.None
            };
        }
        
        public static Ability GetAbilityFromCheck(CheckType checkType)
        {
            switch (checkType)
            {
                case CheckType.SaveStrength:
                case CheckType.SkillAthletics:
                    return Ability.Strength;
                
                case CheckType.SaveDexterity:
                case CheckType.SkillAcrobatics:
                case CheckType.SkillSleightOfHand:
                case CheckType.SkillStealth:
                case CheckType.SkillThievesTools:
                case CheckType.Initiative:
                    return Ability.Dexterity;
                
                case CheckType.SaveConstitution:
                    return Ability.Constitution;
                
                case CheckType.SaveIntelligence:
                case CheckType.SkillArcana:
                case CheckType.SkillHistory:
                case CheckType.SkillInvestigation:
                case CheckType.SkillNature:
                case CheckType.SkillReligion:
                    return Ability.Intelligence;
                
                case CheckType.SaveWisdom:
                case CheckType.SkillAnimalHandling:
                case CheckType.SkillInsight:
                case CheckType.SkillMedicine:
                case CheckType.SkillPerception:
                case CheckType.SkillSurvival:
                    return Ability.Wisdom;
                
                case CheckType.SaveCharisma:
                case CheckType.SkillDeception:
                case CheckType.SkillIntimidation:
                case CheckType.SkillPerformance:
                case CheckType.SkillPersuasion:
                    return Ability.Charisma;
                
                default:
                    return Ability.None;
            }
        }
    }
}