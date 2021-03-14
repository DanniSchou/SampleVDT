namespace Foxes.Game.Network
{
    using UnityEngine;

    public interface INetworkPlayer
    {
        public string Name { get; }
        public Color Color { get; }
    }
}