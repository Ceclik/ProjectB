using ComponentScripts.Items;
using Injectors;
using Services.CharacterServices.InventoryScripts;
using TMPro;
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
        private RectTransform leftHand;

        private IInventoryUIHandler _uiHandler;

        [SerializeField] private RectTransform rightHand;
        
        private RectTransform[] panels;
        private Injector _injector;

        public void Inject(IInventoryUIHandler uiHandler)
        {
            _uiHandler = uiHandler;
        }
        
        private void Awake()
        {
            _injector = GameObject.Find("Injector").GetComponent<Injector>();
            panels = new RectTransform[inventory.AmountOfSlots];
            for (int i = 0; i < inventory.AmountOfSlots; i++)
            {
                panels[i] = Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>();
                panels[i].GetComponent<ItemPanel>().PanelIndex = i;
                _injector.InjectToPanel(panels[i].GetComponent<ItemPanel>());
            }
        }

        private void OnEnable()
        {
           _uiHandler.UpdateUI(inventory, panels);
        }
    }
}