using ComponentScripts.Entities.Character.InventoryScripts;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IInventoryUIHandler
    {
        public void UpdateUI(Inventory inventory, RectTransform[] panels);
    }
}