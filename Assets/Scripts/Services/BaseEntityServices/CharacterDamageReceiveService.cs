using ComponentScripts;
using ComponentScripts.Entities.Enemies;
using Services.CharacterServices.CharacterStatsScripts;

namespace Services.BaseEntityServices
{
    public class CharacterDamageReceiveService : ICharacterDamageReceiver
    {
        private ICharacterHealthHandler _characterHealthHandler;

        public void Inject(ICharacterHealthHandler characterHealthHandler)
        {
            _characterHealthHandler = characterHealthHandler;
        }
        
        public void ReceiveDamage(ActiveEntity hitEntity)
        {
            if (hitEntity is Enemy)
                _characterHealthHandler.DecreaseHealthValue(hitEntity.BaseDamage);
        }
    }
}