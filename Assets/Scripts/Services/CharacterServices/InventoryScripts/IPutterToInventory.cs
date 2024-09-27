using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items;

namespace Services.CharacterServices.InventoryScripts
{
    public interface IPutterToInventory
    {
        public bool PutToInventory(Item item, Inventory inventory);
    }
}