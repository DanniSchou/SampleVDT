namespace Foxes.Game.Externals.Samples
{
    using System.Collections.Generic;
    using Core;
    using JetBrains.Annotations;
    using Presets;
    using Presets.Events;
    using Presets.Models.Actors;
    using UnityEngine;

    [PublicAPI]
    public class SamplePresetService : IPresetService
    {
        [Inject] protected IEventBus EventBus;
        
        public void LoadCharacter(string id)
        {
            CreateSamplePreset(id);
        }

        public void LoadMonster(string id)
        {
            CreateSamplePreset(id);
        }

        private void CreateSamplePreset(string id)
        {
            var actor = new SampleActor(id);
            EventBus.Publish(new ActorLoadedEvent(actor));
        }
    }

    internal class SampleActor : IPresetActor
    {
        public string Id { get; }
        public string Name { get; }

        private readonly CheckModel[] _abilityChecks;
        private readonly CheckModel[] _abilitySaves;
        private readonly CheckModel[] _skillChecks;
        private readonly CheckModel _initiative;
        private readonly CombatModel[] _combatModels;
        private readonly SpellModel[] _spellModels;
        
        public SampleActor(string id)
        {
            Id = id;
            Name = id;

            var proficiency = 2;
            
            _abilityChecks = new[]
            {
                new CheckModel {ActorName = Name, CheckName = "Strength", CheckModifier = Random.Range(-1, 4)},
                new CheckModel {ActorName = Name, CheckName = "Dexterity", CheckModifier = Random.Range(-1, 4)},
                new CheckModel {ActorName = Name, CheckName = "Constitution", CheckModifier = Random.Range(-1, 4)},
                new CheckModel {ActorName = Name, CheckName = "Intelligence", CheckModifier = Random.Range(-1, 4)},
                new CheckModel {ActorName = Name, CheckName = "Wisdom", CheckModifier = Random.Range(-1, 4)},
                new CheckModel {ActorName = Name, CheckName = "Charisma", CheckModifier = Random.Range(-1, 4)}
            };

            var i = 0;
            _abilitySaves = new[]
            {
                new CheckModel {ActorName = Name, CheckName = "Strength", CheckModifier = _abilityChecks[i++].CheckModifier + proficiency},
                new CheckModel {ActorName = Name, CheckName = "Dexterity", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Constitution", CheckModifier = _abilityChecks[i++].CheckModifier + proficiency},
                new CheckModel {ActorName = Name, CheckName = "Intelligence", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Wisdom", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Charisma", CheckModifier = _abilityChecks[i].CheckModifier}
            };

            i = 0;
            _skillChecks = new[]
            {
                new CheckModel {ActorName = Name, CheckName = "Lifting", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Balancing", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Drinking", CheckModifier = _abilityChecks[i++].CheckModifier + proficiency},
                new CheckModel {ActorName = Name, CheckName = "Thinking", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Feeling", CheckModifier = _abilityChecks[i++].CheckModifier},
                new CheckModel {ActorName = Name, CheckName = "Charming", CheckModifier = _abilityChecks[i].CheckModifier + proficiency}
            };

            _initiative = new CheckModel {ActorName = Name, CheckName = "Initiative", CheckModifier = _abilityChecks[1].CheckModifier};

            var strengthModifier = _abilityChecks[0].CheckModifier;
            var unarmedDamage = Mathf.Max(1, strengthModifier + 1);
            _combatModels = new[]
            {
                new CombatModel
                {
                    ActorName = Name,
                    CheckName = "Sword",
                    CheckModifier = strengthModifier + proficiency,
                    DamageModifier = strengthModifier,
                    CombatAction = new CombatAction{ AttackType = CheckType.MeleeWeaponAttacks, Damage = new Damage{Name = "1d6", Count = 1, Value = 6}}
                },
                new CombatModel
                {
                    ActorName = Name,
                    CheckName = "Unarmed Strike",
                    CheckModifier = strengthModifier + proficiency,
                    DamageModifier = 0,
                    CombatAction = new CombatAction
                    {
                        Name = "Unarmed Strike",
                        AttackType = CheckType.MeleeNaturalAttacks,
                        Damage = new Damage
                        {
                            Name = unarmedDamage.ToString(),
                            FixedValue = unarmedDamage,
                            UseFixedValue = true
                        }
                    }
                },
                new CombatModel
                {
                    ActorName = Name,
                    CheckName = "Sneak Attack",
                    CombatAction = new CombatAction{ Damage = new Damage{Name = "2d6", Count = 2, Value = 6}}
                }
            };

            var wisdomModifier = _abilityChecks[4].CheckModifier;
            var charismaModifier = _abilityChecks[5].CheckModifier;
            
            _spellModels = new[]
            {
                new SpellModel
                {
                    ActorName = Name,
                    CheckName = "Eldritch Blast",
                    CheckModifier = charismaModifier + proficiency,
                    DamageModifier = 0,
                    SpellAction = new SpellAction
                    {
                        AttackType = CheckType.RangedSpellAttacks,
                        Damages = new []{new SpellDamage{Level = 0, Damage = new Damage{Name = "1d10", Count = 1, Value = 10}}}
                    }
                },
                new SpellModel
                {
                    ActorName = Name,
                    CheckName = "Cure Wounds",
                    CheckModifier = wisdomModifier + proficiency,
                    DamageModifier = wisdomModifier,
                    SpellAction = new SpellAction
                    {
                        AttackType = CheckType.RangedSpellAttacks,
                        Damages = new []
                        {
                            new SpellDamage{Level = 1, Damage = new Damage{Name = "1d8", Count = 1, Value = 8}},
                            new SpellDamage{Level = 2, Damage = new Damage{Name = "2d8", Count = 2, Value = 8}},
                            new SpellDamage{Level = 3, Damage = new Damage{Name = "3d8", Count = 3, Value = 8}},
                            new SpellDamage{Level = 4, Damage = new Damage{Name = "4d8", Count = 4, Value = 8}}
                        }
                    }
                },
                new SpellModel
                {
                    ActorName = Name,
                    CheckName = "Fireball",
                    CheckModifier = charismaModifier + proficiency,
                    DamageModifier = 0,
                    SpellAction = new SpellAction
                    {
                        Damages = new []
                        {
                            new SpellDamage{Level = 3, Damage = new Damage{Name = "8d6", Count = 8, Value = 6}},
                            new SpellDamage{Level = 4, Damage = new Damage{Name = "9d6", Count = 9, Value = 6}}
                        }
                    }
                }
            };
        }

        public IEnumerable<CheckModel> GetAbilityCheckModels()
        {
            return _abilityChecks;
        }

        public IEnumerable<CheckModel> GetAbilitySaveModels()
        {
            return _abilitySaves;
        }

        public IEnumerable<CheckModel> GetSkillCheckModels()
        {
            return _skillChecks;
        }

        public CheckModel GetInitiativeCheckModel()
        {
            return _initiative;
        }

        public IEnumerable<CheckModel> GetCombatModels()
        {
            return _combatModels;
        }

        public IEnumerable<CheckModel> GetSpellModels()
        {
            return _spellModels;
        }
    }
}