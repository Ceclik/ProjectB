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
        public void UpdateHandsPanels(Inventory inventory, List<MainHandPanel> mainHand, List<SecondHandPanel> secondHand)
        {
            for (int i = 0; i < mainHand.Count; i++)
            {
                if (mainHand[i].DurabilityBar == null)
                {
                    mainHand[i].InitializeUiElements();
                    secondHand[i].InitializeUiElements();
                }

                if (inventory.MainHand != null)
                {
                    mainHand[i].UpdateHandPanel((ToolData)inventory.MainHand);
                }

                if (inventory.SecondHand != null)
                {
                    secondHand[i].UpdateHandPanel((ToolData)inventory.SecondHand);
                }
            }
        }
        
        public void UpdateUI(Inventory inventory, List<RectTransform> panels)
        {
            for (var i = 0; i < panels.Count; i++)
            {
                var itemPanel = panels[i].GetComponent<ItemPanel>();
                
                if (inventory.Items[i] != null)
                {
                    itemPanel.UpdateHandPanel(inventory.Items[i]);
                }
            }
        }
    }
}