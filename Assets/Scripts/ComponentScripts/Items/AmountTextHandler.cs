using TMPro;
using UnityEngine;

namespace ComponentScripts.Items
{
    public class AmountTextHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;
        private Canvas _itemCanvas;
        private Item _measuringItem;

        private void Start()
        {
            _itemCanvas = GetComponentInChildren<Canvas>();
            _itemCanvas.worldCamera = Camera.main;

            _measuringItem = GetComponent<Item>();
            UpdateText();
        }

        public void UpdateText()
        {
            amountText.text = _measuringItem.Amount.ToString();
        }
    }
}