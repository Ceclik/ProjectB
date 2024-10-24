using ComponentScripts.Items;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup itemsPanel;
        [SerializeField] private Inventory inventory;
        [SerializeField] private GameObject itemPanelPrefab;

        [Space(10)] [Header("Hand panels")] [SerializeField]
        private RectTransform mainHand;

        [SerializeField] private RectTransform secondHandHand;

        private IInventoryUIHandler _uiHandler;

        public RectTransform[] Panels { get; private set; }

        private void Awake()
        {
            Panels = new RectTransform[inventory.AmountOfSlots];
            for (var i = 0; i < inventory.AmountOfSlots; i++)
            {
                Panels[i] = Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>();
                Panels[i].GetComponent<ItemPanel>().PanelIndex = i;
            }
        }

        private void OnEnable()
        {
            _uiHandler = new InventoryUIHandlerService();
            _uiHandler.UpdateUI(inventory, Panels);
        }
    }
}