using ComponentScripts;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public class SpawnerService : MonoBehaviour, ISpawner
    {
        public Entity[] SpawnEntities(GameObject entityToSpawn, int entitiesCount, Transform entitiesParent,
            Vector3 nestPosition, float distanceFromNest)
        {
            Entity[] spawnedEntities = new Entity[entitiesCount];
            for (int i = 0; i < entitiesCount; i++)
            {
                Vector3 newEntityPosition = new Vector3(
                    Random.Range(nestPosition.x - distanceFromNest, nestPosition.x + distanceFromNest),
                    Random.Range(nestPosition.y - 1.5f, nestPosition.y + distanceFromNest), nestPosition.z);
                spawnedEntities[i] = Instantiate(entityToSpawn, newEntityPosition, Quaternion.identity, entitiesParent)
                    .GetComponent<Entity>();
            }

            return spawnedEntities;
        }

        public Entity SpawnEntity(GameObject entityToSpawn, Transform entityParent, Vector3 entityPosition)
        {
            return Instantiate(entityToSpawn, entityPosition, Quaternion.identity, entityParent).GetComponent<Entity>();
        }
    }
}