using ComponentScripts;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public interface ICharacterDamageReceiver
    {
        public void ReceiveDamage(ActiveEntity hitEntity);
        public void Inject(ICharacterHealthHandler characterHealthHandler);
    }
}