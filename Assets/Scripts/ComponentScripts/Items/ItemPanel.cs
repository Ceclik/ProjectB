using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public class ItemPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected TextMeshProUGUI AmountText;
        protected Inventory Inventory;
        protected bool IsPointerOnPanel;
        protected Image ItemIcon;

        protected IItemsDropper ItemsDropper;

        private SecondHandPanel _secondHandPanel;
        private MainHandPanel _mainHandPanel;

        public int PanelIndex { get; set; }

        private void Start()
        {
            _secondHandPanel = GameObject.Find("SecondHandPanel").GetComponent<SecondHandPanel>();
            _mainHandPanel = GameObject.Find("MainHandPanel").GetComponent<MainHandPanel>();
            IsPointerOnPanel = false;
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            ItemIcon = GetComponentInChildren<Image>();
            AmountText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void HandleDropping()
        {
            if (Inventory.Items[PanelIndex] != null)
            {
                Debug.Log($"Panel index of dropping item: {PanelIndex}");
                if (Inventory.Items[PanelIndex].Amount - 1 == 0)
                {
                    CleanItemPanel();
                    ItemsDropper.DropItem(Inventory.Items[PanelIndex], Inventory.transform.position);
                    Inventory.Items[PanelIndex] = null;
                }
                else
                {
                    Inventory.Items[PanelIndex].Amount--;
                    AmountText.text = Inventory.Items[PanelIndex].Amount.ToString();
                    var itemToSpawn = new ItemData(Inventory.Items[PanelIndex])
                    {
                        Amount = 1
                    };
                    ItemsDropper.DropItem(itemToSpawn, Inventory.transform.position);
                }
            }
        }

        private void PutToMainHand()
        {
            if (Inventory.Items[PanelIndex] is ToolData || Inventory.Items[PanelIndex] is WeaponData)
            {
                _mainHandPanel.PanelIndex = PanelIndex;
                _mainHandPanel.ItemIcon.sprite = ItemIcon.sprite;
                _mainHandPanel.AmountText.text = AmountText.text;
                CleanItemPanel();
                Inventory.MainHand = Inventory.Items[PanelIndex];
                Inventory.Items[PanelIndex] = null;
            }
        }

        private void PutToSecondHand()
        {
            _secondHandPanel.PanelIndex = PanelIndex;
            _secondHandPanel.ItemIcon.sprite = ItemIcon.sprite;
            _secondHandPanel.AmountText.text = AmountText.text;
            CleanItemPanel();
            Inventory.SecondHand = Inventory.Items[PanelIndex];
            Inventory.Items[PanelIndex] = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && IsPointerOnPanel)
                HandleDropping();
            if(Input.GetKeyDown(KeyCode.Mouse0) && IsPointerOnPanel)
                PutToMainHand();
            if(Input.GetKeyDown(KeyCode.Mouse1) && IsPointerOnPanel)
                PutToSecondHand();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointerOnPanel = true;
            Debug.Log($"Pointer is on {PanelIndex} panel");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointerOnPanel = false;
        }

        public void Inject(IItemsDropper dropper)
        {
            ItemsDropper = dropper;
        }

        protected void CleanItemPanel()
        {
            ItemIcon.sprite = null;
            AmountText.enabled = false;
        }
    }
}