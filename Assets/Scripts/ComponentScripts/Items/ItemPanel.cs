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
        protected IItemsDropper ItemsDropper;
        public TextMeshProUGUI AmountText { get; protected set; }
        public Inventory Inventory { get; protected set; }
        public bool IsPointerOnPanel { get; protected set; }
        public Image ItemIcon { get; protected set; }
        
        public Image DurabilityBarBackgroung { get; protected set; }
        public Image DurabilityBar { get; private set; }

        public int PanelIndex { get; set; }


        private void Awake()
        {
            var images = GetComponentsInChildren<Image>();
            ItemsDropper = gameObject.AddComponent<ItemDropperService>();
            IsPointerOnPanel = false;
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            ItemIcon = images[0];
            DurabilityBarBackgroung = images[1];
            DurabilityBar = images[2];
            AmountText = GetComponentInChildren<TextMeshProUGUI>();
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
            Debug.Log($"Pointer is on {PanelIndex} panel");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointerOnPanel = false;
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

        public void CleanItemPanel()
        {
            ItemIcon.sprite = null;
            AmountText.enabled = false;
            DurabilityBarBackgroung.enabled = false;
            DurabilityBar.enabled = false;
        }
    }
}