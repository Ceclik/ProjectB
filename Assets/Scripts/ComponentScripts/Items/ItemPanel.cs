using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public class ItemPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private bool _isPointerOnPanel;
        private Inventory _inventory;
        private Image _itemIcon;
        private TextMeshProUGUI _amountText;

        private IItemsDropper _itemsDropper;
        
        public int PanelIndex { get; set; }

        public void Inject(IItemsDropper dropper)
        {
            _itemsDropper = dropper;
        }

        private void Start()
        {
            _isPointerOnPanel = false;
            _inventory = GameObject.Find("Character").GetComponent<Inventory>();
            _itemIcon = GetComponentInChildren<Image>();
            _amountText = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOnPanel = true; 
            Debug.Log($"Pointer is on {PanelIndex} panel");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && _isPointerOnPanel)
            {
                if (_inventory.Items[PanelIndex] != null)
                {
                    Debug.Log($"Panel index of dropping item: {PanelIndex}");
                    if (_inventory.Items[PanelIndex].Amount - 1 == 0)
                    {
                        CleanItemPanel();
                        _itemsDropper.DropItem(_inventory.Items[PanelIndex], _inventory.transform.position);
                        _inventory.Items[PanelIndex] = null;
                    }
                    else
                    {
                        _inventory.Items[PanelIndex].Amount--;
                        _amountText.text = _inventory.Items[PanelIndex].Amount.ToString();
                        ItemData itemToSpawn = new ItemData(_inventory.Items[PanelIndex])
                        {
                            Amount = 1
                        };
                        _itemsDropper.DropItem(itemToSpawn, _inventory.transform.position);
                    }
                }
            }
        }

        private void CleanItemPanel()
        {
            _itemIcon.sprite = null;
            _amountText.enabled = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOnPanel = false;
        }
    }
}