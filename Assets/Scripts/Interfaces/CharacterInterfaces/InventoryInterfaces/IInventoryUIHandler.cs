using System.Collections.Generic;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using UnityEngine;

namespace Interfaces.CharacterInterfaces.InventoryInterfaces
{
    public interface IInventoryUIHandler
    {
        public void UpdateUI(Inventory inventory, List<RectTransform> panels);
        public void UpdateHandsPanels(Inventory inventory, MainHandPanel mainHand, SecondHandPanel secondHand);
    }
}