using ComponentScripts;
using ComponentScripts.Entities.Character;
using Interfaces.BaseEntityInterfaces;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public class EntityDamageReceiveService : IEntityDamageReceiver
    {
        public void ReceiveDamage(Character character, Entity hittedEnemy)
        {
            character.CountActualDamage();
            hittedEnemy.ActualHealth -= character.ActualDamage;
        }
    }
}