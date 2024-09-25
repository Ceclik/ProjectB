using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IInventoryUIHandler
    {
        public void UpdateUI(GridLayout itemsPanel);
    }
}