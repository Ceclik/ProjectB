using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int amountOfSlots;
        public ItemData[] Items { get; private set; }

        public ItemData MainHand { get; set; }
        public ItemData SecondHand { get; set; }

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
            for (var i = 0; i < Items.Length; i++)
                if (Items[i] != null)
                    Debug.Log(
                        $"Name: {Items[i].Name}, Amount: {Items[i].Amount}, maxAmount: {Items[i].MaxAvailableAmount}," +
                        $" index: {i}");
                else emptyCount++;

            if (emptyCount == Items.Length)
                Debug.Log("Inventory is empty!");

            Debug.Log(MainHand == null
                ? "Main hand is empty"
                : $"Main hand item\nName: {MainHand.Name}, Amount: {MainHand.Amount}, maxAmount: {MainHand.MaxAvailableAmount}");

            Debug.Log(SecondHand == null
                ? "Second hand is empty"
                : $"Second hand item\nName: {SecondHand.Name}, Amount: {SecondHand.Amount}, maxAmount: {SecondHand.MaxAvailableAmount}");
        }
    }
}