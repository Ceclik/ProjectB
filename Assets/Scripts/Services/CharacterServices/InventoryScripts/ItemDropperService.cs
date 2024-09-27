using System;
using ComponentScripts;
using DataClasses;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class ItemDropperService : MonoBehaviour, IItemsDropper
    {
        private ItemsSpawner _itemsSpawner;
        private Transform _itemsParent;

        private void Start()
        {
            _itemsSpawner = GameObject.Find("ItemsSpawner").GetComponent<ItemsSpawner>();
            _itemsParent = GameObject.Find("Items").transform;
        }

        public void DropItem(ItemData newItem, Vector3 characterPosition)
        {
            Instantiate(_itemsSpawner.GetItemPrefab(newItem), characterPosition, Quaternion.identity, _itemsParent);
        }
    }
}