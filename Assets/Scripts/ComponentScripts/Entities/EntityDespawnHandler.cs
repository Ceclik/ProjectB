using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntityDespawnHandler : MonoBehaviour
    {
        private IDespawner _despawner;
        private Entity _entity;

        private void Start()
        {
            _despawner = gameObject.AddComponent<EntityDespawnerService>();
            _entity = GetComponent<Entity>();
        }

        public void Update()
        {
            if (_entity.ActualHealth <= 0)
                _despawner.Despawn(gameObject);
        }
    }
}