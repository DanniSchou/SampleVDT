namespace Foxes.Game.Presets.Presenters
{
    using Core;
    using Events;
    using TMPro;
    using UnityEngine;

    public class AddMonsterPresenter : InjectedBehaviour
    {
        [Inject] 
        protected IEventBus EventBus;
        
        [SerializeField]
        protected TMP_InputField input;

        public void OnSubmit()
        {
            EventBus.Publish(new AddMonsterRequestedEvent(input.text));
        }
    }
}