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
            Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(characterPosition, 0.2f);

            foreach (var objects in nearbyObjects)
            {
                if (objects.TryGetComponent(out Item droppedItem))
                    if (droppedItem.Name == newItem.Name &&
                        (droppedItem.Amount + newItem.Amount <= droppedItem.MaxAvailableAmount))
                    {
                        droppedItem.Amount += newItem.Amount;
                        droppedItem.GetComponentInChildren<TextMeshProUGUI>().text = droppedItem.Amount.ToString();
                        return;
                    }
            }
            
            Item spawnedItem =
                Instantiate(_itemsSpawner.GetItemPrefab(newItem), characterPosition, Quaternion.identity, _itemsParent)
                    .GetComponent<Item>();
            spawnedItem.Amount = newItem.Amount;
            spawnedItem.GetComponentInChildren<TextMeshProUGUI>().text = newItem.Amount.ToString();
        }
    }
}