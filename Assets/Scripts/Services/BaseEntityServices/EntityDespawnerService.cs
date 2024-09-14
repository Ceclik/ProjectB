using UnityEngine;

namespace Services.BaseEntityServices
{
    public class EntityDespawnerService : MonoBehaviour, IDespawner
    {
        public void Despawn(GameObject destroyingEntity)
        {
            Destroy(destroyingEntity);
        }
    }
}