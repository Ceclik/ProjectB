using System.Collections.Generic;
using ComponentScripts.Items;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
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

        private MainHandPanel _mainHand;
        private ResourceExtractionHandler _resourceExtractionHandler;
        private SecondHandPanel _secondHand;

        private IInventoryUIHandler _uiHandler;

        public List<RectTransform> Panels { get; private set; }


        private void Awake()
        {
            _mainHand = GameObject.Find("MainHandPanel").GetComponent<MainHandPanel>();
            _secondHand = GameObject.Find("SecondHandPanel").GetComponent<SecondHandPanel>();


            _mainHand.InitializeUiElements();
            _secondHand.InitializeUiElements();

            _uiHandler = new InventoryUIHandlerService();
            _resourceExtractionHandler = inventory.GetComponent<ResourceExtractionHandler>();
            Panels = new List<RectTransform>();
            for (var i = 0; i < inventory.AmountOfSlots; i++)
            {
                Panels.Add(Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>());
                Panels[i].GetComponent<ItemPanel>().PanelIndex = i;
            }
        }

        private void OnEnable()
        {
            _uiHandler.UpdateHandsPanels(inventory, _mainHand, _secondHand);
            _uiHandler.UpdateUI(inventory, Panels);
        }

        public void UpdateUIHands()
        {
            _uiHandler.UpdateHandsPanels(inventory, _mainHand, _secondHand);
        }
    }
}