namespace Foxes.Game.Presets.Models.Actors
{
    using System.Collections.Generic;

    public interface IPresetActor
    {
        string Id { get; }
        string Name { get; }
        
        IEnumerable<CheckModel> GetAbilityCheckModels();
        IEnumerable<CheckModel> GetAbilitySaveModels();
        IEnumerable<CheckModel> GetSkillCheckModels();
        CheckModel GetInitiativeCheckModel();
        IEnumerable<CheckModel> GetCombatModels();
        IEnumerable<CheckModel> GetSpellModels();
    }
}