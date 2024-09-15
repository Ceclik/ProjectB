using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.CharacterServices.CharacterAttackScripts
{
    public class CharacterAttackService : ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, float maxDistanceForAttack, Character attackCharacter)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out EntityHealthHandler enemy) &&
                    DistanceCounter(enemy.transform.position, attackCharacter.transform.position) <
                    maxDistanceForAttack)
                    enemy.ReceiveCharacterAttack(attackCharacter);
        }

        private float DistanceCounter(Vector3 characterPosition, Vector3 enemyPosition)
        {
            float xDelta = Mathf.Abs(characterPosition.x - enemyPosition.x);
            float yDelta = Mathf.Abs(characterPosition.y - enemyPosition.y);
            return Mathf.Sqrt(Mathf.Pow(xDelta, 2) + Mathf.Pow(yDelta, 2));
        }
    }
}