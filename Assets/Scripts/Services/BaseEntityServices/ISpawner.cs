using ComponentScripts;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public interface ISpawner
    {
        public Entity[] SpawnEntities(GameObject entityToSpawn, int entitiesCount, Transform entitiesParent,
            Vector3 nestPosition, float distanceFromNest);
        public Entity SpawnEntity(GameObject entityToSpawn, Transform entityParent, Vector3 entityPosition);
    }
}