using ComponentScripts;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Entities.Enemies;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public class CharacterDamageReceiveService : ICharacterDamageReceiver
    {
        private ICharacterHealthHandler _characterHealthHandler;

        public void Inject(ICharacterHealthHandler characterHealthHandler)
        {
            _characterHealthHandler = characterHealthHandler;
        }

        public void ReceiveDamage(ActiveEntity hitEntity, ArmorHandler armorHandler)
        {
            if (hitEntity is Enemy)
            {
                if (armorHandler.IsUsingSchield)
                {
                    
                }
                _characterHealthHandler.DecreaseHealthValue(hitEntity.BaseDamage);
            }
        }
    }
}