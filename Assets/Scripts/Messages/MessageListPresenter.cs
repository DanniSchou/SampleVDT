namespace Foxes.Game.Messages
{
    using System.Collections.Generic;
    using Core;
    using UnityEngine;

    public class MessageListPresenter : InjectedBehaviour
    {
        [Inject] protected MessageListModel ListModel;

        [SerializeField] protected GameObject messageRenderer;

        private Transform _transform;

        private readonly Dictionary<MessageModel, MessagePresenter> _presenterLookup = new Dictionary<MessageModel, MessagePresenter>();
        
        protected override void Awake()
        {
            base.Awake();
            _transform = GetComponent<Transform>();
        }

        protected override void Start()
        {
            base.Start();

            ListModel.MessageAdded += OnMessageAdded;
            ListModel.MessageRemoved += OnMessageRemoved;
        }

        protected void OnDestroy()
        {
            ListModel.MessageAdded -= OnMessageAdded;
            ListModel.MessageRemoved -= OnMessageRemoved;
        }

        private void OnMessageAdded(MessageListModel listModel, MessageModel messageModel)
        {
            var rendererObject = Instantiate(messageRenderer, _transform);
            var component = rendererObject.GetComponent<MessagePresenter>();
            component.SetModel(messageModel);
            
            _presenterLookup.Add(messageModel, component);
        }

        private void OnMessageRemoved(MessageListModel listModel, MessageModel messageModel)
        {
            if (!_presenterLookup.TryGetValue(messageModel, out var presenter)) return;
            
            _presenterLookup.Remove(messageModel);
            Destroy(presenter.gameObject);
        }
    }
}
