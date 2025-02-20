using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ToolsDurabilityDecreaser : MonoBehaviour
    {
        [SerializeField] private int durabilityDecreasePerUse;
        [SerializeField] private InventoryUI inventoryUI;

        private Inventory _inventory;
        

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
        }

        public void DecreaseToolDurability()
        {
            var mainHandTool = (ToolData)_inventory.MainHand.Value;
            mainHandTool.ActualDurability -= durabilityDecreasePerUse;
            inventoryUI.UpdateUIHands();
        }

        public void DecreaseShieldDurability()
        {
            if (_inventory.SecondHand.Value is ShieldData)
            {
                var shield = (ShieldData)_inventory.SecondHand.Value;
                shield.ActualDurability -= durabilityDecreasePerUse;
                inventoryUI.UpdateUIHands();
            }
        }
    }
}