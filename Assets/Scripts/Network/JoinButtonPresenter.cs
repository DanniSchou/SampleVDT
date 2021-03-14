namespace Foxes.Game.Network
{
    using Core;
    using Events;
    using TMPro;
    using UnityEngine;

    public class JoinButtonPresenter : InjectedBehaviour
    {
        [Inject] protected IEventBus EventBus;
        
        [SerializeField] protected TMP_Text textField;

        private string _roomName;
        
        public void OnClick()
        {
            EventBus.Publish(new JoinRoomRequestedEvent(_roomName));
        }

        public void SetText(string value)
        {
            _roomName = value;
            textField.text = _roomName;
        }
    }
}