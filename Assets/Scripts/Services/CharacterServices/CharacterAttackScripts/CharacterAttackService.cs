using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using ComponentScripts.Entities.ResourceObjects;
using DataClasses;
using Interfaces.CharacterInterfaces.CharacterAttackInterfaces;
using UnityEngine;

namespace Services.CharacterServices.CharacterAttackScripts
{
    public class CharacterAttackService : ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, float maxDistanceForAttack, Character attackCharacter)
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out EntityHealthHandler enemy) &&
                    Vector2.Distance(enemy.transform.position, attackCharacter.transform.position)
                    < maxDistanceForAttack)
                {
                    if (enemy.TryGetComponent(out ResourceObject ro))
                        return;

                    enemy.ReceiveCharacterAttack(attackCharacter);
                    enemy.GetComponent<EnemyKicksReceiver>().ReceiveKick(attackCharacter.transform.position);
                    if (attackCharacter.Inventory.MainHand.Value is WeaponData)
                    {
                        attackCharacter.GetComponent<ToolsDurabilityDecreaser>().DecreaseToolDurability();
                    }
                }
            }
        }
    }
}