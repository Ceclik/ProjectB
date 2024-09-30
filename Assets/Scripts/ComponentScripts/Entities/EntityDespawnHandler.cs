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
            _entity = GetComponent<Entity>();
        }

        public void Update()
        {
            if (_entity.ActualHealth <= 0)
                _despawner.Despawn(gameObject);
        }

        public void Inject(IDespawner despawner)
        {
            _despawner = despawner;
        }
    }
}