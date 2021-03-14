namespace Foxes.Game.Network
{
    using System;
    using JetBrains.Annotations;

    [PublicAPI]
    public class NetworkModel
    {
        public event Action<NetworkModel> RoomNameChanged;
        public event Action<NetworkModel> RoomListChanged;
        public event Action<NetworkModel> IsConnectedToRoomChanged;

        private string _roomName;

        public string RoomName
        {
            get => _roomName;
            set
            {
                if (Equals(_roomName, value)) return;
                _roomName = value;
                RoomNameChanged?.Invoke(this);
            }
        }

        private string[] _roomList;
        
        public string[] RoomList
        {
            get => _roomList;
            set
            {
                _roomList = value;
                RoomListChanged?.Invoke(this);
            }
        }

        private bool _isConnectedToRoom;
        
        public bool IsConnectedToRoom
        {
            get => _isConnectedToRoom;
            set
            {
                _isConnectedToRoom = value;
                IsConnectedToRoomChanged?.Invoke(this);
            }
        }
    }
}