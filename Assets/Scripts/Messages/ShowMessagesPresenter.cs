namespace Foxes.Game.Messages
{
    using Core;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class ShowMessagesPresenter : InjectedBehaviour
    {
        [Inject] protected MessageListModel MessageListModel;
        
        [SerializeField] protected Button button;
        [SerializeField] protected TMP_Text text;

        protected override void Start()
        {
            base.Start();
            
            button.onClick.AddListener(OnClick);
            MessageListModel.ShowMessagesChanged += OnShowMessagesChanged;
            
            OnShowMessagesChanged(MessageListModel);
        }

        private void OnShowMessagesChanged(MessageListModel model)
        {
            text.text = $"History: {(model.ShowMessages ? "Shown" : "Hidden")}";
        }

        private void OnClick()
        {
            MessageListModel.ShowMessages = !MessageListModel.ShowMessages;
        }
    }
}