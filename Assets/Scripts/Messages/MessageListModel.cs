namespace Foxes.Game.Messages
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [PublicAPI]
    public class MessageListModel
    {
        public event Action<MessageListModel, MessageModel> MessageAdded;
        public event Action<MessageListModel, MessageModel> MessageRemoved;
        public event Action<MessageListModel> ShowMessagesChanged;
        
        private readonly List<MessageModel> _messages;
        private bool _showMessages;

        public IEnumerable<MessageModel> Messages => _messages;

        public bool ShowMessages
        {
            get => _showMessages;
            set
            {
                if (_showMessages == value) return;
                _showMessages = value;
                ShowMessagesChanged?.Invoke(this);
            } 
        }

        public MessageListModel()
        {
            _messages = new List<MessageModel>();
        }

        public void AddMessage(MessageModel message)
        {
            _messages.Add(message);
            MessageAdded?.Invoke(this, message);
        }
        
        public void RemoveMessage(MessageModel message)
        {
            _messages.Remove(message);
            MessageRemoved?.Invoke(this, message);
        }
    }
}