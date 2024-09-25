using System;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GridLayout itemsPanel;
        [SerializeField] private Inventory inventory;
        [SerializeField] private GameObject itemPanelPrefab;

        [Space(10)] [Header("Hand panels")] [SerializeField]
        private RectTransform leftHand;

        [SerializeField] private RectTransform rightHand;
        
        private RectTransform[] panels;

        private void Start()
        {
            panels = new RectTransform[inventory.AmountOfSlots];
            for (int i = 0; i < inventory.AmountOfSlots; i++)
            {
                panels[i] = Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>();
            }
        }
    }
}