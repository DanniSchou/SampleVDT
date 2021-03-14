namespace Foxes.Game.Network
{
    using UnityEngine;

    public interface INetworkObjectFactory
    {
        GameObject NetworkInstantiate(GameObject prefab, Vector3 position, Quaternion rotation);
        
        GameObject NetworkInstantiate(string prefabName, Vector3 position, Quaternion rotation);
        
        void NetworkDestroy(GameObject target);
    }
}