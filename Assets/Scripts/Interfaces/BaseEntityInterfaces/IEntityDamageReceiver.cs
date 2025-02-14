using ComponentScripts;
using ComponentScripts.Entities.Character;

namespace Services.BaseEntityServices
{
    public interface IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy);
    }
}