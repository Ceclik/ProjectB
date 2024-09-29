using ComponentScripts;
using ComponentScripts.Items;
using DataClasses;
using TMPro;
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
            Item spawnedItem =
                Instantiate(_itemsSpawner.GetItemPrefab(newItem), characterPosition, Quaternion.identity, _itemsParent)
                    .GetComponent<Item>();
            spawnedItem.Amount = newItem.Amount;
            spawnedItem.GetComponentInChildren<TextMeshProUGUI>().text = newItem.Amount.ToString();
        }
    }
}