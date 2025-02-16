using ComponentScripts.Entities.ResourceObjects;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.ResourceObjectScripts
{
    public class ObjectDestroyer : MonoBehaviour
    {
        public delegate void UpdateNavMesh();

        private IItemsDropper _itemsDropper;
        private ResourceObject _resource;

        private void Start()
        {
            _resource = GetComponent<ResourceObject>();
            _itemsDropper = gameObject.AddComponent<ItemDropperService>();
        }

        private void Update()
        {
            if (_resource.ActualHealth <= 0)
                DropResource();
        }

        private void OnDestroy()
        {
            OnObjectDestroyed?.Invoke();
        }

        public event UpdateNavMesh OnObjectDestroyed;

        private void DropResource()
        {
            foreach (var item in _resource.DroppingItems) _itemsDropper.DropItem(item, transform.position);

            Destroy(gameObject);
        }
    }
}