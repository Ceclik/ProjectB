using ComponentScripts;
using ComponentScripts.Items;
using ComponentScripts.Items.Tools;
using ComponentScripts.Items.Weapons;
using DataClasses;
using TMPro;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class ItemDropperService : MonoBehaviour, IItemsDropper
    {
        private Transform _itemsParent;
        private ItemsSpawner _itemsSpawner;

        private void Start()
        {
            _itemsSpawner = GameObject.FindGameObjectWithTag("ItemsSpawner").GetComponent<ItemsSpawner>();
            _itemsParent = GameObject.FindGameObjectWithTag("ItemsParent").transform;
        }

        public void DropItem(ItemData newItem, Vector3 characterPosition)
        {
            var nearbyObjects = Physics2D.OverlapCircleAll(characterPosition, 0.2f);

            foreach (var objects in nearbyObjects)
                if (objects.TryGetComponent(out Item droppedItem))
                    if (droppedItem.Name == newItem.Name &&
                        droppedItem.Amount + newItem.Amount <= droppedItem.MaxAvailableAmount)
                    {
                        droppedItem.Amount += newItem.Amount;
                        droppedItem.GetComponentInChildren<TextMeshProUGUI>().text = droppedItem.Amount.ToString();
                        return;
                    }

            var spawnedItem =
                Instantiate(_itemsSpawner.GetItemPrefab(newItem), characterPosition, Quaternion.identity, _itemsParent)
                    .GetComponent<Item>();
            spawnedItem.Amount = newItem.Amount;
            if(!(spawnedItem is Weapon) && !(spawnedItem is Tool))
                spawnedItem.GetComponentInChildren<TextMeshProUGUI>().text = newItem.Amount.ToString();
        }
    }
}