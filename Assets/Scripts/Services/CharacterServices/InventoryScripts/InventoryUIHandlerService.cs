using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using DataClasses;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class InventoryUIHandlerService : IInventoryUIHandler
    {
        public void UpdateUI(Inventory inventory, RectTransform[] panels)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var itemPanel = panels[i].GetComponent<ItemPanel>();
                Debug.Log($"item panel: {itemPanel}");
                itemPanel.DurabilityBarBackgroung.enabled = false;
                itemPanel.DurabilityBar.enabled = false;
                itemPanel.AmountText.enabled = false;
                
                if (inventory.Items[i] != null)
                {
                    itemPanel.ItemIcon.sprite = inventory.Items[i].ItemIcon;
                    
                    if (!(inventory.Items[i] is ToolData) && !itemPanel.AmountText.isActiveAndEnabled)
                    {
                        itemPanel.AmountText.enabled = true;
                        itemPanel.AmountText.text = inventory.Items[i].Amount.ToString();
                    }
                    else if (inventory.Items[i] is ToolData && !itemPanel.AmountText.isActiveAndEnabled)
                    {
                        itemPanel.DurabilityBarBackgroung.enabled = true;
                        itemPanel.DurabilityBar.enabled = true;
                        var currentItem = (ToolData)inventory.Items[i];
                        itemPanel.DurabilityBar.fillAmount = currentItem.ActualDurability * 100 / currentItem.InitialDurability;
                        Debug.Log(
                            $"fill amount: {itemPanel.DurabilityBar.fillAmount}, actual durability: {currentItem.ActualDurability}," +
                            $" initial durability: {currentItem.InitialDurability}");
                    }
                }
            }
        }
    }
}