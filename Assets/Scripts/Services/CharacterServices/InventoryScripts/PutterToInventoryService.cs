using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using ComponentScripts.Items.Food;
using ComponentScripts.Items.Ingredients;
using ComponentScripts.Items.Tools;
using ComponentScripts.Items.Weapons;
using DataClasses;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class PutterToInventoryService : IPutterToInventory
    {
        public bool PutToInventory(Item item, Inventory inventory)
        {
            var itemToInventory = CreateItemDataObject(item);
            foreach (var inventoryItem in inventory.Items)
                if (inventoryItem != null)
                {
                    if (inventoryItem.Name == itemToInventory.Name &&
                        inventoryItem.Amount + itemToInventory.Amount <= inventoryItem.MaxAvailableAmount)
                    {
                        inventoryItem.Amount += itemToInventory.Amount;
                        Debug.Log("Just increasing amount");
                        DebugInventoryState(inventory);
                        return true;
                    }

                    if (inventoryItem.Name == itemToInventory.Name &&
                        inventoryItem.Amount + itemToInventory.Amount > inventoryItem.MaxAvailableAmount)
                    {
                        Debug.Log("Increasing amount and creating new field");
                        var delta = inventoryItem.MaxAvailableAmount - inventoryItem.Amount;
                        inventoryItem.Amount += delta;
                        itemToInventory.Amount -= delta;
                        var indexI = GetEmptySlot(inventory);
                        if (indexI != -1)
                        {
                            inventory.Items[indexI] = itemToInventory;
                            DebugInventoryState(inventory);
                            return true;
                        }

                        Debug.LogError("Inventory is full"); //TODO create UI warning
                        return false;
                    }
                }

            Debug.Log("Creating new field");
            var index = GetEmptySlot(inventory);
            if (index != -1)
            {
                inventory.Items[index] = itemToInventory;
                DebugInventoryState(inventory);
                return true;
            }

            Debug.LogError("Inventory is full"); //TODO create UI warning
            return false;
        }

        public int PutToInventory(ItemData itemToInventory, Inventory inventory)
        {
            for (var i = 0; i < inventory.Items.Length; i++)
                if (inventory.Items[i] != null)
                {
                    if (inventory.Items[i].Name == itemToInventory.Name &&
                        inventory.Items[i].Amount + itemToInventory.Amount <= inventory.Items[i].MaxAvailableAmount)
                    {
                        inventory.Items[i].Amount += itemToInventory.Amount;
                        Debug.Log("Just increasing amount");
                        DebugInventoryState(inventory);
                        return i;
                    }

                    if (inventory.Items[i].Name == itemToInventory.Name &&
                        inventory.Items[i].Amount + itemToInventory.Amount > inventory.Items[i].MaxAvailableAmount)
                    {
                        Debug.Log("Increasing amount and creating new field");
                        var delta = inventory.Items[i].MaxAvailableAmount - inventory.Items[i].Amount;
                        inventory.Items[i].Amount += delta;
                        itemToInventory.Amount -= delta;
                        var indexi = GetEmptySlot(inventory);
                        if (indexi != -1)
                        {
                            inventory.Items[indexi] = itemToInventory;
                            DebugInventoryState(inventory);
                            return i;
                        }

                        Debug.LogError("Inventory is full"); //TODO create UI warning
                        return -1;
                    }
                }


            Debug.Log("Creating new field");
            var index = GetEmptySlot(inventory);
            if (index != -1)
            {
                inventory.Items[index] = itemToInventory;
                DebugInventoryState(inventory);
                return index;
            }

            Debug.LogError("Inventory is full"); //TODO create UI warning
            return -1;
        }

        private void DebugInventoryState(Inventory inventory)
        {
            Debug.Log("Inventory: ");
            for (var i = 0; i < inventory.Items.Length; i++)
                if (inventory.Items[i] != null)
                    Debug.Log(
                        $"Name: {inventory.Items[i].Name}, Amount: {inventory.Items[i].Amount}, maxAmount: " +
                        $"{inventory.Items[i].MaxAvailableAmount}, index: {i}");
        }

        private ItemData CreateItemDataObject(Item receivedItem)
        {
            if (receivedItem is Food)
                return new FoodData((Food)receivedItem);
            if (receivedItem is Weapon)
                return new WeaponData((Weapon)receivedItem);
            if (receivedItem is Tool)
            {
                return (Tool)receivedItem is Shield
                    ? new ShieldData((Shield)receivedItem)
                    : new ToolData((Tool)receivedItem);
            }
            if (receivedItem is Ingredient)
                return new IngredientData((Ingredient)receivedItem);
            return null;
        }

        private int GetEmptySlot(Inventory inventory)
        {
            for (var i = 0; i < inventory.Items.Length; i++)
                if (inventory.Items[i] == null)
                    return i;

            return -1;
        }
    }
}