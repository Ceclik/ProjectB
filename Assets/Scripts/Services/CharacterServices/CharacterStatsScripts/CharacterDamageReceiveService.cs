using ComponentScripts;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Entities.Enemies;
using UnityEngine;

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
            int receivedDamage = 0;
            if (hitEntity is Enemy)
            {
                if (armorHandler.IsUsingShield)
                {
                    receivedDamage = (int)(hitEntity.BaseDamage * (armorHandler.PercentOfBlockingDamage / 100));
                    _characterHealthHandler.DecreaseHealthValue(receivedDamage);
                    Debug.Log($"Received damage is: {receivedDamage}");
                    return;
                }
                receivedDamage = hitEntity.BaseDamage;
                _characterHealthHandler.DecreaseHealthValue(receivedDamage);
                Debug.Log($"Received damage is: {receivedDamage}");
            }
        }
    }
}