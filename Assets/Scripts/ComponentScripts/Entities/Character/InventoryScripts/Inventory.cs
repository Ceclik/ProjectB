using System.Collections.Generic;
using ComponentScripts.Items;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int amountOfSlots;
        
        private List<Item> _items;
        
        public List<Item> Items => _items;
        
        private void Start()
        {
            _items = new List<Item>(amountOfSlots);
            for(int i = 0; i < amountOfSlots; i++)
                _items.Add(null);
        }
    }
}