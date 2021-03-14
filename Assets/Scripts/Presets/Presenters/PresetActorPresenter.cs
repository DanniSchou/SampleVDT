namespace Foxes.Game.Presets.Presenters
{
    using Core;
    using Events;
    using Models;
    using Models.Actors;

    public class PresetActorPresenter : PresetGroupPresenter
    {
        [Inject] protected IEventBus EventBus;
        [Inject] protected PresetModel PresetModel;

        public string PresetId { get; set; }

        protected override void Awake()
        {
            base.Awake();
            
            LayoutTransform = content;
        }

        protected override void Start()
        {
            base.Start();

            PresetModel.ActorRemoved += OnActorRemoved;
        }

        protected void OnDestroy()
        {
            PresetModel.ActorRemoved -= OnActorRemoved;
        }

        public void OnCloseClicked()
        {
            EventBus.Publish(new RemovePresetRequestedEvent(PresetId));
        }

        private void OnActorRemoved(PresetModel model, IPresetActor actor)
        {
            if (actor.Id == PresetId)
            {
                Destroy(gameObject);
            }
        }
    }
}