using System.Collections.Generic;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using DataClasses;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public class InventoryUIHandlerService : IInventoryUIHandler
    {
        public void UpdateHandsPanels(Inventory inventory, MainHandPanel mainHand, SecondHandPanel secondHand)
        {
            if (inventory.MainHand.Value != null)
                mainHand.UpdateHandPanel((ToolData)inventory.MainHand.Value);
            else if (inventory.MainHand.Value == null) mainHand.CleanItemPanel();

            if (inventory.SecondHand.Value != null)
                secondHand.UpdateHandPanel((ToolData)inventory.SecondHand.Value);
            else if (inventory.SecondHand.Value == null) secondHand.CleanItemPanel();
        }

        public void UpdateUI(Inventory inventory, List<RectTransform> panels)
        {
            for (var i = 0; i < panels.Count; i++)
            {
                var itemPanel = panels[i].GetComponent<ItemPanel>();
                if (itemPanel.DurabilityBar == null) itemPanel.InitializeUiElements();

                if (inventory.Items[i] != null) itemPanel.UpdateHandPanel(inventory.Items[i]);
            }
        }
    }
}