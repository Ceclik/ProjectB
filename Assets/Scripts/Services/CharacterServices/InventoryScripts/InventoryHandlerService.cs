using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using ComponentScripts.Items.Food;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class InventoryHandlerService : IInventoryHandler
    {
        public bool PutToInventory(Item item, Inventory inventory)
        {
            foreach (var inventoryItem in inventory.Items)
            {
                if (inventoryItem != null)
                {
                    Debug.Log("inside active logic");
                    if (inventoryItem.Name == item.Name &&
                        inventoryItem.Amount + item.Amount < inventoryItem.MaxAvailableAmount)
                    {
                        inventoryItem.Amount += item.Amount;
                        Debug.Log("Just increasing amount");
                        DebugInventoryState(inventory);
                        return true;
                    }
                    if (inventoryItem.Name == item.Name &&
                             !(inventoryItem.Amount + item.Amount < inventoryItem.MaxAvailableAmount))
                    {
                        Debug.Log("Increasing amount and creating new field");
                        int delta = inventoryItem.MaxAvailableAmount - inventoryItem.Amount;
                        inventoryItem.Amount += delta;
                        item.Amount -= delta;
                        int index = HasEmptySlot(inventory);
                        if (index != -1)
                        {
                            inventory.Items[index] = item;
                            DebugInventoryState(inventory);
                            return true;
                        }
                        else
                        {
                            Debug.LogError("Inventory is full"); //TODO create UI warning
                            return false;
                        }
                    }
                    else
                    {
                        Debug.Log("Creating new field");
                        int index = HasEmptySlot(inventory);
                        if (index != -1)
                        {
                            inventory.Items[index] = item;
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

            Debug.Log("inventory is empty, creating new field");
            inventory.Items[0] = item;
            
            DebugInventoryState(inventory);
            return false;
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

        public void ThrowFromInventory(Item item, Inventory inventory)
        {
            throw new System.NotImplementedException();
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