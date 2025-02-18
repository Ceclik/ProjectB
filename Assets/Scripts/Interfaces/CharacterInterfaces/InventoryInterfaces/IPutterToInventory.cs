using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using DataClasses;

namespace Interfaces.CharacterInterfaces.InventoryInterfaces
{
    public interface IPutterToInventory
    {
        public bool PutToInventory(Item item, Inventory inventory);
        public int PutToInventory(ItemData itemToInventory, Inventory inventory);
    }
}