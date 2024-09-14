using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;

namespace Services.BaseEntityServices
{
    public class EnemyDamageReceiveService : IEnemyDamageReceiver
    {
        public void ReceiveDamage(Character character, Enemy hittedEnemy)
        {
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }
    }
}