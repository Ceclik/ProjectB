using ComponentScripts.Items;
using Injectors;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;
using UnityEngine.Serialization;
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
        
        private Injector _injector;

        private IInventoryUIHandler _uiHandler;

        private RectTransform[] panels;
        public RectTransform[] Panels => panels;

        private void Awake()
        {
            _injector = GameObject.FindGameObjectWithTag("Injector").GetComponent<Injector>();
            panels = new RectTransform[inventory.AmountOfSlots];
            for (var i = 0; i < inventory.AmountOfSlots; i++)
            {
                panels[i] = Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>();
                panels[i].GetComponent<ItemPanel>().PanelIndex = i;
                _injector.InjectToPanel(panels[i].GetComponent<ItemPanel>());
            }
            _injector.InjectToPanel(mainHand.GetComponent<MainHandPanel>());
            _injector.InjectToPanel(secondHandHand.GetComponent<SecondHandPanel>());
        }

        private void OnEnable()
        {
            _uiHandler.UpdateUI(inventory, panels);
        }

        public void Inject(IInventoryUIHandler uiHandler)
        {
            _uiHandler = uiHandler;
        }
    }
}