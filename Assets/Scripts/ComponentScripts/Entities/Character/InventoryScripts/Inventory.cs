using System.Collections.Generic;
using ComponentScripts.Items;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int amountOfSlots;
        public Item[] Items{ get; set; }
        
        private void Start()
        {
            Items = new Item[amountOfSlots];
            for (int i = 0; i < amountOfSlots; i++)
                Items[i] = null;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.B))
                WatchInventory();
        }

        private void WatchInventory()
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    Debug.Log($"Name: {item.Name}, Amount: {item.Amount}, maxAmount: {item.MaxAvailableAmount}");
                }
            }
            Debug.Log("Empty!");
            
        }
    }
}