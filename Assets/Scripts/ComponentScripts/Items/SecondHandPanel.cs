using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Items
{
    public class SecondHandPanel : ItemPanel
    {
        private InventoryUI _panelsHandler;
        private IPutterToInventory _putterToInventory;
        
        
        private void Start()
        {
            _panelsHandler = GetComponentInParent<InventoryUI>();
            _putterToInventory = new PutterToInventoryService();
            IsPointerOnPanel = false;
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && IsPointerOnPanel)
                HandleDropping();
            if (Input.GetKeyDown(KeyCode.Mouse1) && IsPointerOnPanel)
                PutToInventory();
        }

        private void HandleDropping()
        {
            if (Inventory.SecondHand != null)
            {
                ItemsDropper.DropItem(Inventory.SecondHand, Inventory.transform.position);
                Inventory.SecondHand = null;
                CleanItemPanel();
            }
        }

        private void PutToInventory()
        {
            var itemIndex = _putterToInventory.PutToInventory(Inventory.SecondHand, Inventory);
            var targetPanel = _panelsHandler.Panels[itemIndex].GetComponent<ItemPanel>();
            var itemData = (ToolData)Inventory.SecondHand;
            targetPanel.ItemIcon.sprite = itemData.ItemIcon;
            targetPanel.AmountText.text = itemData.Amount.ToString();
            targetPanel.DurabilityBarBackgroung.enabled = true;
            targetPanel.DurabilityBar.enabled = true;
            targetPanel.DurabilityBar.fillAmount = (float)itemData.ActualDurability / itemData.InitialDurability;
            CleanItemPanel();
            PanelIndex = -1;
            Inventory.SecondHand = null;
        }
    }
}