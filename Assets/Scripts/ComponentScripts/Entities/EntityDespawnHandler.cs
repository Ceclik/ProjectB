using Interfaces;
using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntityDespawnHandler : MonoBehaviour
    {
        private IDespawner _despawner;
        private Entity _entity;

        public void Inject(IDespawner despawner)
        {
            _despawner = despawner;
        }

        private void Start()
        {
            _entity = GetComponent<Entity>();
        }

        public void Update()
        {
            if(_entity.ActualHealth <= 0)
                _despawner.Despawn(gameObject);
        }
    }
}