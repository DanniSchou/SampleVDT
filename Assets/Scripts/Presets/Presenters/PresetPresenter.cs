namespace Foxes.Game.Presets.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Models;
    using Models.Actors;
    using UnityEngine;

    public class PresetPresenter : InjectedBehaviour
    {
        [Inject] protected PresetModel PresetModel;
       
        [SerializeField] 
        protected GameObject presetActor;
        
        [SerializeField] 
        protected GameObject presetGroup;
        
        [SerializeField] 
        protected GameObject presetCheck;

        [SerializeField]
        protected GameObject presetAction;

        [SerializeField]
        protected GameObject presetSpell;
        
        [SerializeField]
        protected Transform content;

        private Dictionary<Type, Action<CheckModel>> _factoryMethods;
        private PresetActorPresenter _currentActor;
        private PresetGroupPresenter _currentGroup;

        protected override void Awake()
        {
            base.Awake();

            _factoryMethods = new Dictionary<Type, Action<CheckModel>>
            {
                {typeof(CheckModel), SpawnCheck},
                {typeof(CombatModel), SpawnAction},
                {typeof(SpellModel), SpawnSpell}
            };
        }

        protected override void Start()
        {
            base.Start();

            PresetModel.ActorAdded += OnActorAdded;
        }

        protected void OnDestroy()
        {
            PresetModel.ActorAdded -= OnActorAdded;
        }

        private void OnActorAdded(PresetModel model, IPresetActor actor)
        {
            AddActor(actor);
        }
        
        private void AddActor(IPresetActor actor)
        {
            SpawnActor(actor);
            GenerateAbilityChecks(actor);
            GenerateSaveChecks(actor);
            GenerateSkillChecks(actor);
            GenerateCombatRolls(actor);
            GenerateSpellRolls(actor);
        }

        private void SpawnActor(IPresetActor characterData)
        {
            var groupObject = Instantiate(presetActor, content);
            _currentActor = groupObject.GetComponent<PresetActorPresenter>();
            _currentActor.SetName(characterData.Name);
            _currentActor.PresetId = characterData.Id;
        }

        private void SpawnGroup(string groupName)
        {
            var groupObject = Instantiate(presetGroup, _currentActor.Content);
            _currentGroup = groupObject.GetComponent<PresetGroupPresenter>();
            _currentGroup.SetName(groupName);
        }

        private void SpawnFromFactory(CheckModel model)
        {
            if (_factoryMethods.TryGetValue(model.GetType(), out var factoryMethod))
            {
                factoryMethod(model);
            }
        }

        private void SpawnCheck(CheckModel model)
        {
            var presetObject = Instantiate(presetCheck, _currentGroup.Content);
            var presetBehaviour = presetObject.GetComponent<PresetCheckPresenter>();
            presetBehaviour.SetModel(model);
        }

        private void SpawnAction(CheckModel model)
        {
            var presetObject = Instantiate(presetAction, _currentGroup.Content);
            var presetBehaviour = presetObject.GetComponent<PresetActionPresenter>();
            presetBehaviour.SetModel(model);
        }

        private void SpawnSpell(CheckModel model)
        {
            var presetObject = Instantiate(presetSpell, _currentGroup.Content);
            var presetBehaviour = presetObject.GetComponent<PresetSpellPresenter>();
            presetBehaviour.SetModel(model);
        }

        private void GenerateAbilityChecks(IPresetActor actor)
        {
            SpawnGroup("Abilities");
            
            foreach (var model in actor.GetAbilityCheckModels())
            {
                SpawnFromFactory(model);
            }
            
            _currentGroup.ToggleGroup();
        }

        private void GenerateSaveChecks(IPresetActor actor)
        {
            SpawnGroup("Saves");
            
            foreach (var model in actor.GetAbilitySaveModels())
            {
                SpawnFromFactory(model);
            }
            
            _currentGroup.ToggleGroup();
        }

        private void GenerateSkillChecks(IPresetActor actor)
        {
            SpawnGroup("Skills");
            
            foreach (var model in actor.GetSkillCheckModels())
            {
                SpawnFromFactory(model);
            }

            _currentGroup.ToggleGroup();
        }

        private void GenerateCombatRolls(IPresetActor actor)
        {
            SpawnGroup("Combat");
            
            SpawnCheck(actor.GetInitiativeCheckModel());
            
            foreach (var model in actor.GetCombatModels())
            {
                SpawnFromFactory(model);
            }
            
            _currentGroup.ToggleGroup();
        }

        private void GenerateSpellRolls(IPresetActor actor)
        {
            var models = actor.GetSpellModels();
            var checkModels = models as CheckModel[] ?? models.ToArray();
            if (checkModels.Length == 0) return;
            
            SpawnGroup("Spells");
            
            foreach (var model in checkModels)
            {
                SpawnFromFactory(model);
            }
            
            _currentGroup.ToggleGroup();
        }
    }
}
