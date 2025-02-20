using System.Collections.Generic;
using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public class ItemPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected List<TextMeshProUGUI> AmountTexts;

        protected List<Image> DurabilityBarBackgrounds;

        protected List<Image> DurabilityBars;

        protected List<Image> ItemIcons;
        protected IItemsDropper ItemsDropper;

        public TextMeshProUGUI AmountText => AmountTexts[0];
        public Inventory Inventory { get; protected set; }
        public bool IsPointerOnPanel { get; protected set; }
        public Image ItemIcon => ItemIcons[0];
        public Image DurabilityBarBackgroung => DurabilityBarBackgrounds[0];
        public Image DurabilityBar => DurabilityBars[0];

        public int PanelIndex { get; set; }


        private void Awake()
        {
            InitializeUiElements();
        }

        private void Start()
        {
            ItemsDropper = gameObject.AddComponent<ItemDropperService>();
            IsPointerOnPanel = false;
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && IsPointerOnPanel)
                HandleDropping();
        }

        private void OnDisable()
        {
            IsPointerOnPanel = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointerOnPanel = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointerOnPanel = false;
        }

        public void InitializeUiElements()
        {
            var images = GetComponentsInChildren<Image>();
            AmountTexts = new List<TextMeshProUGUI> { GetComponentInChildren<TextMeshProUGUI>() };
            ItemIcons = new List<Image> { images[0] };
            DurabilityBarBackgrounds = new List<Image> { images[1] };
            DurabilityBars = new List<Image> { images[2] };
        }

        private void DisableElements(int i)
        {
            ItemIcons[i].sprite = null;
            AmountTexts[i].enabled = false;
            DurabilityBarBackgrounds[i].enabled = false;
            DurabilityBars[i].enabled = false;
        }

        public void UpdateHandPanel(ItemData handItem)
        {
            for (var i = 0; i < AmountTexts.Count; i++)
            {
                DisableElements(i);

                ItemIcons[i].sprite = handItem.ItemIcon;
                if (!(handItem is ToolData) && !AmountText.isActiveAndEnabled)
                {
                    AmountTexts[i].enabled = true;
                    AmountTexts[i].text = handItem.Amount.ToString();
                }
                else if (handItem is ToolData && !AmountTexts[i].isActiveAndEnabled)
                {
                    var toolItem = (ToolData)handItem;
                    DurabilityBarBackgrounds[i].enabled = true;
                    DurabilityBars[i].enabled = true;
                    DurabilityBars[i].fillAmount = (float)toolItem.ActualDurability / toolItem.InitialDurability;
                }
            }
        }

        private void HandleDropping()
        {
            if (Inventory.Items[PanelIndex] != null)
            {
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

        public void CleanItemPanel()
        {
            for (var i = 0; i < AmountTexts.Count; i++)
            {
                ItemIcons[i].sprite = null;
                AmountTexts[i].enabled = false;
                DurabilityBarBackgrounds[i].enabled = false;
                DurabilityBars[i].enabled = false;
            }
        }
    }
}