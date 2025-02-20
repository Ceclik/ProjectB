using System.Collections.Generic;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Items
{
    public class FunctionalHandsPutter : MonoBehaviour
    {
        private ItemPanel _itemPanel;
        private MainHandPanel _mainHandPanel;
        private SecondHandPanel _secondHandPanel;

        private void Start()
        {
            _secondHandPanel = GameObject.Find("SecondHandPanel").GetComponent<SecondHandPanel>();
            _mainHandPanel = GameObject.Find("MainHandPanel").GetComponent<MainHandPanel>();
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
                _itemPanel.Inventory.MainHand.Value == null)
            {
                _mainHandPanel.PanelIndex = _itemPanel.PanelIndex;
                _mainHandPanel.PutToHand(_itemPanel);
                _itemPanel.CleanItemPanel();
                _itemPanel.Inventory.MainHand = new KeyValuePair<int, ItemData>(_itemPanel.PanelIndex,
                    _itemPanel.Inventory.Items[_itemPanel.PanelIndex]);
                _itemPanel.Inventory.Items[_itemPanel.PanelIndex] = null;
            }
        }

        private void PutToSecondHand()
        {
            if (_itemPanel.Inventory.Items[_itemPanel.PanelIndex] is ToolData &&
                _itemPanel.Inventory.SecondHand.Value == null)
            {
                _secondHandPanel.PanelIndex = _itemPanel.PanelIndex;
                _secondHandPanel.PutToHand(_itemPanel);
                _itemPanel.CleanItemPanel();
                _itemPanel.Inventory.SecondHand = new KeyValuePair<int, ItemData>(_itemPanel.PanelIndex,
                    _itemPanel.Inventory.Items[_itemPanel.PanelIndex]);
                _itemPanel.Inventory.Items[_itemPanel.PanelIndex] = null;
            }
        }
    }
}