using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using Services.CharacterServices.CharacterStatsScripts;

namespace Services.BaseEntityServices
{
    public class EnemyDamageReceiveService : IEnemyDamageReceiver
    {
        public void ReceiveDamage(Character character, Enemy hittedEnemy)
        {
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }

        public void Inject(ICharacterHealthHandler characterHealthHandler)
        {
            throw new System.NotImplementedException();
        }
    }
}