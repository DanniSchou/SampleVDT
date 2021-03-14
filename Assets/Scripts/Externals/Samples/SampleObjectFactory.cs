namespace Foxes.Game.Externals.Samples
{
    using Network;
    using UnityEngine;

    public class SampleObjectFactory : INetworkObjectFactory
    {
        public GameObject NetworkInstantiate(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(prefab, position, rotation);
        }

        public GameObject NetworkInstantiate(string prefabName, Vector3 position, Quaternion rotation)
        {
            var prefab = Resources.Load<GameObject>(prefabName);
            return NetworkInstantiate(prefab, position, rotation);
        }

        public void NetworkDestroy(GameObject target)
        {
            Object.Destroy(target);
        }
    }
}