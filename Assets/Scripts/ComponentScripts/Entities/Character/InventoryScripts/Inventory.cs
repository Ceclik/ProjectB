using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        public delegate void UpdateHandsUI(ItemData item);

        [SerializeField] private int amountOfSlots;

        private ItemData _mainHand;
        private ItemData _secondHand;
        public ItemData[] Items { get; private set; }

        public ItemData MainHand
        {
            get => _mainHand;
            set
            {
                if (_mainHand != value)
                {
                    _mainHand = value;
                    OnMainHandUpdate?.Invoke(value);
                }
            }
        }

        public ItemData SecondHand
        {
            get => _secondHand;
            set
            {
                if (_secondHand != value)
                {
                    _secondHand = value;
                    OnSecondHandUpdate?.Invoke(value);
                }
            }
        }

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

        public event UpdateHandsUI OnMainHandUpdate;
        public event UpdateHandsUI OnSecondHandUpdate;

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