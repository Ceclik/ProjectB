using ComponentScripts;
using ComponentScripts.Entities.Character;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public interface ICharacterDamageReceiver
    {
        public void ReceiveDamage(ActiveEntity hitEntity, ArmorHandler armorHandler);
    }
}