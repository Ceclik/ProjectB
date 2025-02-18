using ComponentScripts.Entities.Character.InventoryScripts;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            if (Inventory.SecondHand != null)
            {
                Debug.Log("Panel index of dropping item: second hand");
                ItemsDropper.DropItem(Inventory.SecondHand, Inventory.transform.position);
                Inventory.SecondHand = null;
                CleanItemPanel();
            }
        }

        private void PutToInventory()
        {
            var itemIndex = _putterToInventory.PutToInventory(Inventory.SecondHand, Inventory);
            _panelsHandler.Panels[itemIndex].GetComponentInChildren<Image>().sprite = Inventory.SecondHand.ItemIcon;
            _panelsHandler.Panels[itemIndex].GetComponentInChildren<TextMeshProUGUI>().text =
                Inventory.SecondHand.Amount.ToString();
            CleanItemPanel();
            Inventory.SecondHand = null;
            PanelIndex = -1;
        }
    }
}