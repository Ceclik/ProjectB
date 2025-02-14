using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;
using DataClasses;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IPutterToInventory
    {
        public bool PutToInventory(Item item, Inventory inventory);
        public int PutToInventory(ItemData itemToInventory, Inventory inventory);
    }
}