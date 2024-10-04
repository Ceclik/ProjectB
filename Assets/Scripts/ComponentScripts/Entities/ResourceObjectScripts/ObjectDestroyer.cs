using ComponentScripts.Entities.ResourceObjects;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.ResourceObjectScripts
{
    public class ObjectDestroyer : MonoBehaviour
    {
        private IItemsDropper _itemsDropper;
        private ResourceObject _resource;

        private void Start()
        {
            _resource = GetComponent<ResourceObject>();
            _itemsDropper = gameObject.AddComponent<ItemDropperService>();
        }

        private void Update()
        {
            //Debug.Log($"Tree actual healh: {_resource.ActualHealth}");
            if (_resource.ActualHealth <= 0)
                DropResource();
        }

        private void DropResource()
        {
            foreach (var item in _resource.DroppingItems) _itemsDropper.DropItem(item, transform.position);

            Destroy(gameObject);
        }
    }
}