using DataClasses;
using UnityEngine;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IItemsDropper
    {
        public void DropItem(ItemData newItem, Vector3 characterPosition);
    }
}