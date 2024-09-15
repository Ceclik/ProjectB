using ComponentScripts;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;

namespace Services.BaseEntityServices
{
    public interface IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy);
    }
}