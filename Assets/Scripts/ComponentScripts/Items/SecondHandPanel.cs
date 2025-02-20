using System.Collections.Generic;
using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
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
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && IsPointerOnPanel && Inventory.SecondHand.Value != null)
                HandleDropping();
            if (Input.GetKeyDown(KeyCode.Mouse1) && IsPointerOnPanel && Inventory.SecondHand.Value != null)
                PutToInventory();
        }

        public new void InitializeUiElements()
        {
            base.InitializeUiElements();

            var secondPanel = GameObject.Find("SecondHandPanelUI").GetComponent<RectTransform>();
            var images = secondPanel.GetComponentsInChildren<Image>();
            AmountTexts.Add(GetComponentInChildren<TextMeshProUGUI>());
            ItemIcons.Add(images[0]);
            DurabilityBarBackgrounds.Add(images[1]);
            DurabilityBars.Add(images[2]);
        }

        private void HandleDropping()
        {
            if (Inventory.SecondHand.Value != null)
            {
                ItemsDropper.DropItem(Inventory.SecondHand.Value, Inventory.transform.position);
                Inventory.SecondHand = new KeyValuePair<int, ItemData>(-1, null);
                CleanItemPanel();
            }
        }

        public void PutToHand(ItemPanel itemPanel)
        {
            for (var i = 0; i < AmountTexts.Count; i++)
            {
                ItemIcons[i].sprite = itemPanel.ItemIcon.sprite;
                if (!(itemPanel.Inventory.Items[PanelIndex] is ToolData))
                {
                    AmountTexts[i].text = itemPanel.AmountText.text;
                }
                else
                {
                    DurabilityBarBackgrounds[i].enabled = true;
                    DurabilityBars[i].enabled = true;
                    DurabilityBars[i].fillAmount = itemPanel.DurabilityBar.fillAmount;
                }
            }
        }

        private void PutToInventory()
        {
            var itemIndex = _putterToInventory.PutToInventory(Inventory.SecondHand.Value, Inventory);
            var targetPanel = _panelsHandler.Panels[itemIndex].GetComponent<ItemPanel>();
            var itemData = (ToolData)Inventory.SecondHand.Value;
            targetPanel.ItemIcon.sprite = itemData.ItemIcon;
            targetPanel.AmountText.text = itemData.Amount.ToString();
            targetPanel.DurabilityBarBackgroung.enabled = true;
            targetPanel.DurabilityBar.enabled = true;
            targetPanel.DurabilityBar.fillAmount = (float)itemData.ActualDurability / itemData.InitialDurability;
            CleanItemPanel();
            PanelIndex = -1;
            Inventory.SecondHand = new KeyValuePair<int, ItemData>(-1, null);
        }
    }
}