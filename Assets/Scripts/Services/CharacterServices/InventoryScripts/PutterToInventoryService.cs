using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using ComponentScripts.Items.Food;
using DataClasses;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class PutterToInventoryService : IPutterToInventory
    {
        public bool PutToInventory(Item item, Inventory inventory)
        {
            ItemData itemToInventory = CreateItemDataObject(item);
            foreach (var inventoryItem in inventory.Items)
            {
                if (inventoryItem != null)
                {
                    if (inventoryItem.Name == itemToInventory.Name &&
                        inventoryItem.Amount + itemToInventory.Amount < inventoryItem.MaxAvailableAmount)
                    {
                        inventoryItem.Amount += itemToInventory.Amount;
                        Debug.Log("Just increasing amount");
                        DebugInventoryState(inventory);
                        return true;
                    }
                    else if (inventoryItem.Name == itemToInventory.Name &&
                             inventoryItem.Amount + itemToInventory.Amount > inventoryItem.MaxAvailableAmount)
                    {
                        Debug.Log("Increasing amount and creating new field");
                        int delta = inventoryItem.MaxAvailableAmount - inventoryItem.Amount;
                        inventoryItem.Amount += delta;
                        itemToInventory.Amount -= delta;
                        int indexi = HasEmptySlot(inventory);
                        if (indexi != -1)
                        {
                            inventory.Items[indexi] = itemToInventory;
                            DebugInventoryState(inventory);
                            return true;
                        }
                        else
                        {
                            Debug.LogError("Inventory is full"); //TODO create UI warning
                            return false;
                        }
                    }
                }
            }

            Debug.Log("Creating new field");
            int index = HasEmptySlot(inventory);
            if (index != -1)
            {
                inventory.Items[index] = itemToInventory;
                DebugInventoryState(inventory);
                return true;
            }
            else
            {
                Debug.LogError("Inventory is full"); //TODO create UI warning
                return false;
            }
        }

        private void DebugInventoryState(Inventory inventory)
        {
            Debug.Log("Inventory: ");
            foreach (var item in inventory.Items)
            {
                if(item != null)
                    Debug.Log($"Name: {item.Name}, Amount: {item.Amount}, maxAmount: {item.MaxAvailableAmount}");
            }
            
        }

        private ItemData CreateItemDataObject(Item receivedItem)
        {
            if (receivedItem is Food)
                return new FoodData((Food)receivedItem);
            else return null;
        }

        private int HasEmptySlot(Inventory inventory)
        {
            for (int i = 0; i < inventory.Items.Length; i++)
            {
                if (inventory.Items[i] == null)
                    return i;
            }

            return -1;
        }
    }
}