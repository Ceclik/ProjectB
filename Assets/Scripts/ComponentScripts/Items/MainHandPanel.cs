using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public class MainHandPanel : ItemPanel
    {
        private InventoryUI _panelsHandler;
        private IPutterToInventory _putterToInventory;

        private void Start()
        {
            _panelsHandler = GetComponentInParent<InventoryUI>();
            _putterToInventory = new PutterToInventoryService();
            IsPointerOnPanel = false;
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            ItemIcon = GetComponentInChildren<Image>();
            AmountText = GetComponentInChildren<TextMeshProUGUI>();
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
            if (Inventory.MainHand != null)
            {
                Debug.Log("Panel index of dropping item: main hand");
                ItemsDropper.DropItem(Inventory.MainHand, Inventory.transform.position);
                Inventory.MainHand = null;
                CleanItemPanel();
            }
        }

        private void PutToInventory()
        {
            var itemIndex = _putterToInventory.PutToInventory(Inventory.MainHand, Inventory);
            var targetPanel = _panelsHandler.Panels[itemIndex].GetComponent<ItemPanel>();
            var itemData = (ToolData)Inventory.MainHand;
            targetPanel.ItemIcon.sprite = itemData.ItemIcon;
            targetPanel.AmountText.text = itemData.Amount.ToString();
            targetPanel.DurabilityBarBackgroung.enabled = true;
            targetPanel.DurabilityBar.fillAmount = itemData.ActualDurability * 100 / itemData.InitialDurability;
            CleanItemPanel();
            PanelIndex = -1;
            Inventory.MainHand = null;
        }
    }
}