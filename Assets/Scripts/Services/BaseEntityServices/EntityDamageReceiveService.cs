using ComponentScripts;
using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public class EntityDamageReceiveService : IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy)
        {
            character.CountActualDamage();
            Debug.Log($"Received damage: {character.ActualDamage}");
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }
    }
}