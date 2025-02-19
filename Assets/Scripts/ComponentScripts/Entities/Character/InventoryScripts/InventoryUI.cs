using System;
using System.Collections.Generic;
using ComponentScripts.Items;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
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
        
        [Space(10)] [Header("Hand's inventory panels")] [SerializeField]
        private List<MainHandPanel> mainHands;
        [SerializeField] private List<SecondHandPanel> secondHands;

        private IInventoryUIHandler _uiHandler;
        private ResourceExtractionHandler _resourceExtractionHandler;
        
        public List<RectTransform> Panels { get; private set; }
        

        private void Awake()
        {
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

        private void Start()
        {
            _resourceExtractionHandler.OnToolUse += UpdateUIHands;
            
        }

        private void UpdateUIHands()
        {
            _uiHandler.UpdateHandsPanels(inventory, mainHands, secondHands);
        }

        private void OnEnable()
        {
            _uiHandler.UpdateHandsPanels(inventory, mainHands, secondHands);
            _uiHandler.UpdateUI(inventory, Panels);
        }

        private void OnDestroy()
        {
            _resourceExtractionHandler.OnToolUse -= UpdateUIHands;
        }
    }
}