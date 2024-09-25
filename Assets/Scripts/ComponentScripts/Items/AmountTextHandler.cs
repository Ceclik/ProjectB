using TMPro;
using UnityEngine;

namespace ComponentScripts.Items
{
    public class AmountTextHandler : MonoBehaviour
    {
        private Canvas _itemCanvas;
        [SerializeField]private TextMeshProUGUI amountText;
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