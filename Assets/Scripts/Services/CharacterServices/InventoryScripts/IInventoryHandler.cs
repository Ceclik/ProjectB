using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IInventoryHandler
    {
        public bool PutToInventory(Item item, Inventory inventory);
        public void ThrowFromInventory(Item item, Inventory inventory);
    }
}