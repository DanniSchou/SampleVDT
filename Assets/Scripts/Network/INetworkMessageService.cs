namespace Foxes.Game.Network
{
    using UnityEngine;

    public interface INetworkMessageService
    {
        void SendMessage(string message, Color color);
    }
}