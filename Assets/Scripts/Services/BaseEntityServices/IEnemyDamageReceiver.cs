using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;

namespace Services.BaseEntityServices
{
    public interface IEnemyDamageReceiver
    {
        public void ReceiveDamage(Character character, Enemy hittedEnemy);
    }
}