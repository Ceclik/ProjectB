using System.Collections.Generic;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        public delegate void UpdateHandsUI(ItemData item);

        [SerializeField] private int amountOfSlots;

        private KeyValuePair<int, ItemData> _mainHand;

        private KeyValuePair<int, ItemData> _secondHand;
        //public ItemData[] Items { get; private set; }

        public Dictionary<int, ItemData> Items { get; private set; }

        public KeyValuePair<int, ItemData> MainHand
        {
            get => _mainHand;
            set
            {
                if (_mainHand.Value != value.Value)
                {
                    _mainHand = value;
                    OnMainHandUpdate?.Invoke(value.Value);
                }
            }
        }

        public KeyValuePair<int, ItemData> SecondHand
        {
            get => _secondHand;
            set
            {
                if (_secondHand.Value != value.Value)
                {
                    _secondHand = value;
                    OnSecondHandUpdate?.Invoke(value.Value);
                }
            }
        }

        public int AmountOfSlots => amountOfSlots;

        private void Start()
        {
            Items = new Dictionary<int, ItemData>(amountOfSlots);
            for (var i = 0; i < amountOfSlots; i++)
                Items[i] = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
                WatchInventory();
        }

        public void DeleteBrokenItem(KeyValuePair<int, ItemData> item)
        {
            Items.Remove(item.Key);
        }

        public event UpdateHandsUI OnMainHandUpdate;
        public event UpdateHandsUI OnSecondHandUpdate;

        private void WatchInventory()
        {
            var emptyCount = 0;
            for (var i = 0; i < Items.Count; i++)
                if (Items[i] != null)
                    Debug.Log(
                        $"Name: {Items[i].Name}, Amount: {Items[i].Amount}, maxAmount: {Items[i].MaxAvailableAmount}," +
                        $" index: {i}");
                else emptyCount++;

            if (emptyCount == Items.Count)
                Debug.Log("Inventory is empty!");

            Debug.Log(MainHand.Value == null
                ? "Main hand is empty"
                : $"Main hand item\nName: {MainHand.Value.Name}, Amount: {MainHand.Value.Amount}, maxAmount: {MainHand.Value.MaxAvailableAmount}");

            Debug.Log(SecondHand.Value == null
                ? "Second hand is empty"
                : $"Second hand item\nName: {SecondHand.Value.Name}, Amount: {SecondHand.Value.Amount}, maxAmount: {SecondHand.Value.MaxAvailableAmount}");
        }
    }
}