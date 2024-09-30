using ComponentScripts;
using ComponentScripts.Entities.Character;

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