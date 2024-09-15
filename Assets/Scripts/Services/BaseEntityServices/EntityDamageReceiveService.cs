using ComponentScripts;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;

namespace Services.BaseEntityServices
{
    public class EntityDamageReceiveService : IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy)
        {
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }
    }
}