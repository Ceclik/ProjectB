using ComponentScripts.Entities.Character.InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.CharacterServices.InventoryScripts
{
    public class InventoryUIHandlerService : IInventoryUIHandler
    {
        public void UpdateUI(Inventory inventory, RectTransform[] panels)
        {
            for (var i = 0; i < panels.Length; i++)
                if (inventory.Items[i] != null)
                {
                    var itemImage = panels[i].GetComponentInChildren<Image>();
                    itemImage.sprite = inventory.Items[i].ItemIcon;
                    var amountText = panels[i].GetComponentInChildren<TextMeshProUGUI>();
                    if (!amountText.isActiveAndEnabled)
                        amountText.enabled = true;
                    amountText.text = inventory.Items[i].Amount.ToString();
                }
        }
    }
}