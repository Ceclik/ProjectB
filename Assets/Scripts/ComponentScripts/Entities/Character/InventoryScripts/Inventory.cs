using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int amountOfSlots;
        public ItemData[] Items { get; private set; }

        public int AmountOfSlots => amountOfSlots;

        private void Start()
        {
            Items = new ItemData[amountOfSlots];
            for (var i = 0; i < amountOfSlots; i++)
                Items[i] = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
                WatchInventory();
        }

        private void WatchInventory()
        {
            var emptyCount = 0;
            foreach (var item in Items)
                if (item != null)
                    Debug.Log(
                        $"Name: {item.Name}, Amount: {item.Amount}, maxAmount: {item.MaxAvailableAmount}");
                else
                    emptyCount++;
            if (emptyCount == Items.Length)
                Debug.Log("Empty!");
        }
    }
}