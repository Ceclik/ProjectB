using System.Collections.Generic;
using DataClasses;
using UnityEngine;

namespace Interfaces.CharacterInterfaces.InventoryInterfaces
{
    public interface IItemsDropper
    {
        public void DropItem(ItemData newItem, Vector3 characterPosition);
        public void DropAllItems(Dictionary<int, ItemData> items, Vector3 characterPosition, float droppingRadius);
    }
}