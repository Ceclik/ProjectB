using ComponentScripts;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public interface ICharacterDamageReceiver
    {
        public void ReceiveDamage(ActiveEntity hitEntity, ArmorHandler armorHandler);
        public void Inject(ICharacterHealthHandler characterHealthHandler);
    }
}