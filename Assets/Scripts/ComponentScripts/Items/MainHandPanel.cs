using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public class MainHandPanel : ItemPanel
    {
        private IPutterToInventory _putterToInventory;
        private InventoryUI _panelsHandler;
        
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
            if(Input.GetKeyDown(KeyCode.Mouse1) && IsPointerOnPanel)
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
            int itemIndex = _putterToInventory.PutToInventory(Inventory.MainHand, Inventory);
            _panelsHandler.Panels[itemIndex].GetComponentInChildren<Image>().sprite = Inventory.MainHand.ItemIcon;
            _panelsHandler.Panels[itemIndex].GetComponentInChildren<TextMeshProUGUI>().text =
                Inventory.MainHand.Amount.ToString();
            CleanItemPanel();
            PanelIndex = -1;
            Inventory.MainHand = null;
        }
        
    }
}