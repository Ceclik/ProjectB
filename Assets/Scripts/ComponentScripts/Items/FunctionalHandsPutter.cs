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
                _itemPanel.Inventory.MainHand == null)
            {
                _mainHandPanel.PanelIndex = _itemPanel.PanelIndex;
                _mainHandPanel.ItemIcon.sprite = _itemPanel.ItemIcon.sprite;
                _mainHandPanel.AmountText.text = _itemPanel.AmountText.text;
                _mainHandPanel.DurabilityBarBackgroung.enabled = true;
                _mainHandPanel.DurabilityBar.enabled = true;
                _mainHandPanel.DurabilityBar.fillAmount = _itemPanel.DurabilityBar.fillAmount;
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
                _secondHandPanel.PanelIndex = _itemPanel.PanelIndex;
                _secondHandPanel.ItemIcon.sprite = _itemPanel.ItemIcon.sprite;
                _secondHandPanel.AmountText.text = _itemPanel.AmountText.text;
                _secondHandPanel.DurabilityBarBackgroung.enabled = true;
                _secondHandPanel.DurabilityBar.enabled = true;
                _secondHandPanel.DurabilityBar.fillAmount = _itemPanel.DurabilityBar.fillAmount;
                _itemPanel.CleanItemPanel();
                _itemPanel.Inventory.SecondHand = _itemPanel.Inventory.Items[_itemPanel.PanelIndex];
                _itemPanel.Inventory.Items[_itemPanel.PanelIndex] = null;
            }
        }
    }
}