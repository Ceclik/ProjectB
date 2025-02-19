using System.Collections.Generic;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Items
{
    public class FunctionalHandsPutter : MonoBehaviour
    {
        private ItemPanel _itemPanel;
        private MainHandPanel _mainHandPanels;
        private SecondHandPanel _secondHandPanels;

        private void Start()
        {
            _secondHandPanels = GameObject.Find("SecondHandPanel").GetComponent<SecondHandPanel>();
            _mainHandPanels = GameObject.Find("MainHandPanel").GetComponent<MainHandPanel>();
            _itemPanel = GetComponent<ItemPanel>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _itemPanel.IsPointerOnPanel)
                PutToMainHand();
            if (Input.GetKeyDown(KeyCode.Mouse1) && _itemPanel.IsPointerOnPanel)
                PutToSecondHand();
        }

        private void PutToMainHand()
        {
            if ((_itemPanel.Inventory.Items[_itemPanel.PanelIndex] is ToolData ||
                 _itemPanel.Inventory.Items[_itemPanel.PanelIndex] is WeaponData) &&
                _itemPanel.Inventory.MainHand == null)
            {
                _mainHandPanels.PanelIndex = _itemPanel.PanelIndex;
                _mainHandPanels.ItemIcon.sprite = _itemPanel.ItemIcon.sprite;
                _mainHandPanels.AmountText.text = _itemPanel.AmountText.text;
                _mainHandPanels.DurabilityBarBackgroung.enabled = true;
                _mainHandPanels.DurabilityBar.enabled = true;
                _mainHandPanels.DurabilityBar.fillAmount = _itemPanel.DurabilityBar.fillAmount;
                _itemPanel.CleanItemPanel();
                _itemPanel.Inventory.MainHand = _itemPanel.Inventory.Items[_itemPanel.PanelIndex];
                _itemPanel.Inventory.Items[_itemPanel.PanelIndex] = null;
            }
        }

        private void PutToSecondHand()
        {
            if (_itemPanel.Inventory.Items[_itemPanel.PanelIndex] is ToolData &&
                _itemPanel.Inventory.SecondHand == null)
            {
                _secondHandPanels.PanelIndex = _itemPanel.PanelIndex;
                _secondHandPanels.ItemIcon.sprite = _itemPanel.ItemIcon.sprite;
                _secondHandPanels.AmountText.text = _itemPanel.AmountText.text;
                _secondHandPanels.DurabilityBarBackgroung.enabled = true;
                _secondHandPanels.DurabilityBar.enabled = true;
                _secondHandPanels.DurabilityBar.fillAmount = _itemPanel.DurabilityBar.fillAmount;
                _itemPanel.CleanItemPanel();
                _itemPanel.Inventory.SecondHand = _itemPanel.Inventory.Items[_itemPanel.PanelIndex];
                _itemPanel.Inventory.Items[_itemPanel.PanelIndex] = null;
            }
        }
    }
}