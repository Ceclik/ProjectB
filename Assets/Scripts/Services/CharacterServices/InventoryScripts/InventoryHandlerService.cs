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
            bool isPut = false;
            foreach (var inventoryItem in inventory.Items)
            {
                if (inventoryItem != null)
                {
                    if (inventoryItem.Name == item.Name &&
                        inventoryItem.Amount + item.Amount < inventoryItem.MaxAvailableAmount)
                    {
                        inventoryItem.Amount += item.Amount;
                        isPut = true;
                        DebugInventoryState(inventory);
                        return true;
                    }
                    else if (inventoryItem.Name == item.Name &&
                             !(inventoryItem.Amount + item.Amount < inventoryItem.MaxAvailableAmount))
                    {
                        int delta = inventoryItem.MaxAvailableAmount - inventoryItem.Amount;
                        inventoryItem.Amount += delta;
                        item.Amount -= delta;
                        Item itemVar = HasEmptySlot(inventory);
                        if (itemVar == null)
                        {
                            itemVar = item;
                            isPut = true;
                            DebugInventoryState(inventory);
                            return true;
                        }
                    }
                    else
                    {
                        Item itemVar = HasEmptySlot(inventory);
                        if (itemVar == null)
                        {
                            itemVar = item;
                            isPut = true;
                            DebugInventoryState(inventory);
                            return true;
                        }
                        
                    }
                }
            }

            if (!isPut)
            {
                
            }
            
            DebugInventoryState(inventory);
            return false;
        }

        private void DebugInventoryState(Inventory inventory)
        {
            Debug.Log("Inventory: ");
            foreach (var item in inventory.Items)
            {
                Debug.Log($"Name: {item.Name}, Amount: {item.Amount}, maxAmount: {item.MaxAvailableAmount}");
            }
            
        }

        public void ThrowFromInventory(Item item, Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        private Item HasEmptySlot(Inventory inventory)
        {
            foreach (var item in inventory.Items)
            {
                if (item == null) return item;
            }

            return new Potato(); 
        }
    }
}