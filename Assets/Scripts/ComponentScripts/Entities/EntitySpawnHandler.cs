using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntitySpawnHandler : MonoBehaviour
    {
        public delegate void InjectDependencies(Entity spawnedEntity);

        public event InjectDependencies OnEntitySpawn;

        protected void InvokeOnEntitySpawnEvent(Entity spawnedEntity)
        {
            OnEntitySpawn?.Invoke(spawnedEntity);
        }
    }
}