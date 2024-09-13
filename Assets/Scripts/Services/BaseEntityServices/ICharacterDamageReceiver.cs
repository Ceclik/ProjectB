using ComponentScripts;
using Services.CharacterServices.CharacterStatsScripts;

namespace Services.BaseEntityServices
{
    public interface ICharacterDamageReceiver
    {
        public void ReceiveDamage(ActiveEntity hitEntity);
        public void Inject(ICharacterHealthHandler characterHealthHandler);
    }
}