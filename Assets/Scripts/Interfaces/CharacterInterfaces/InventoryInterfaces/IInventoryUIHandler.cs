using ComponentScripts.Entities.Character.InventoryScripts;
using UnityEngine;

namespace Interfaces.CharacterInterfaces.InventoryInterfaces
{
    public interface IInventoryUIHandler
    {
        public void UpdateUI(Inventory inventory, RectTransform[] panels);
    }
}