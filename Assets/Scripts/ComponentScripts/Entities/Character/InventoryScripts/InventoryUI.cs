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

        [SerializeField] private RectTransform rightHand;
        
        private RectTransform[] panels;

        private void Awake()
        {
            panels = new RectTransform[inventory.AmountOfSlots];
            for (int i = 0; i < inventory.AmountOfSlots; i++)
            {
                panels[i] = Instantiate(itemPanelPrefab, itemsPanel.GetComponent<RectTransform>())
                    .GetComponent<RectTransform>();
            }
        }

        private void OnEnable()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (inventory.Items[i] != null)
                {
                    Image itemImage = panels[i].GetComponentInChildren<Image>();
                    itemImage.sprite = inventory.Items[i].ItemIcon;
                    TextMeshProUGUI amountText = panels[i].GetComponentInChildren<TextMeshProUGUI>();
                    amountText.text = inventory.Items[i].Amount.ToString();
                }
            }
        }
    }
}