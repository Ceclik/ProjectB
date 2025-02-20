using ComponentScripts;
using ComponentScripts.Entities.Character;

namespace Interfaces.BaseEntityInterfaces
{
    public interface IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy);
    }
}