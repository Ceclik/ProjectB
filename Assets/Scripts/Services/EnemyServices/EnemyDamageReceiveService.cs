using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using Services.BaseEntityServices;

namespace Services.EnemyServices
{
    public class EnemyDamageReceiveService : IEnemyDamageReceiver
    {
        public void ReceiveDamage(Character character, Enemy hittedEnemy)
        {
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }
    }
}