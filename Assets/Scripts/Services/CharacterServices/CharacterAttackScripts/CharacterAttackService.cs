using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Entities.ResourceObjects;
using UnityEngine;

namespace Services.CharacterServices.CharacterAttackScripts
{
    public class CharacterAttackService : ICharacterAttackHandler
    {
        
        public void Attack(Vector3 mousePosition, float maxDistanceForAttack, Character attackCharacter)
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out EntityHealthHandler enemy) &&
                    DistanceCounter(enemy.transform.position, attackCharacter.transform.position) <
                    maxDistanceForAttack)
                {
                    if (enemy.TryGetComponent(out ResourceObject ro))
                        return;
                    
                    enemy.ReceiveCharacterAttack(attackCharacter);
                }
        }

        public float DistanceCounter(Vector3 characterPosition, Vector3 enemyPosition)
        {
            var xDelta = Mathf.Abs(characterPosition.x - enemyPosition.x);
            var yDelta = Mathf.Abs(characterPosition.y - enemyPosition.y);
            return Mathf.Sqrt(Mathf.Pow(xDelta, 2) + Mathf.Pow(yDelta, 2));
        }
    }
}