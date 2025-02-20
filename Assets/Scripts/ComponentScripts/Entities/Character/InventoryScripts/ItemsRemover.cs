using System.Collections.Generic;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ItemsRemover : MonoBehaviour
    {
        [SerializeField] private InventoryUI inventoryUI;

        public void RemoveItem(Dictionary<int, ItemData> tools, KeyValuePair<int, ItemData> item)
        {
            tools.Remove(item.Key);
            inventoryUI.UpdateUIHands();
        }

        public void RemoveFromMainHand(Inventory inventory)
        {
            inventory.MainHand = new KeyValuePair<int, ItemData>(-1, null);
            inventoryUI.UpdateUIHands();
        }

        public void RemoveFromSecondHand(Inventory inventory)
        {
            inventory.SecondHand = new KeyValuePair<int, ItemData>(-1, null);
            inventoryUI.UpdateUIHands();
        }
    }
}