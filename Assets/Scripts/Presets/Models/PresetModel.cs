namespace Foxes.Game.Presets.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Actors;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class PresetModel
    {
        public event Action<PresetModel, IPresetActor> ActorAdded;
        public event Action<PresetModel, IPresetActor> ActorRemoved;
        
        private readonly List<IPresetActor> _actors;

        public PresetModel()
        {
            _actors = new List<IPresetActor>();
        }

        public void Add(IPresetActor actor)
        {
            var conflictingActor = _actors.FirstOrDefault(x => x.Id == actor.Id);
            if (conflictingActor != null)
            {
                Remove(conflictingActor);
            }
            
            _actors.Add(actor);
            ActorAdded?.Invoke(this, actor);
        }

        public void Remove(IPresetActor actor)
        {
            _actors.Remove(actor);
            ActorRemoved?.Invoke(this, actor);
        }

        public IPresetActor GetFromId(string id)
        {
            return _actors.FirstOrDefault(x => x.Id == id);
        }
    }
}