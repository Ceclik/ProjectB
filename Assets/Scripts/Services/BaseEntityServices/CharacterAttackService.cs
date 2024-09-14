using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public class CharacterAttackService : ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, Transform enemiesParent, Vector3 characterPosition,
            float maxDistanceForAttack, Character attackCharacter)
        {
            //Debug.Log($"Mouse coordinates: {mousePosition.ToString()}");
            /*for (int i = 0; i < enemiesParent.childCount; i++)
            {
                if (mousePosition == enemiesParent.GetChild(i).position &&
                    DistanceCounter(characterPosition, mousePosition) < maxDistanceForAttack)
                {
                    enemiesParent.GetChild(i).GetComponent<EnemyHealthHandler>().ReceiveCharacterAttack(attackCharacter);
                }
            }*/
            
            Ray ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
            //Debug.Log($"{ray.ToString()}");
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("After hit");
                if (hit.collider.TryGetComponent(out EnemyHealthHandler enemy))
                {
                    Debug.Log("Receiving damage");
                    enemy.ReceiveCharacterAttack(attackCharacter);
                }
            }

        }

        private float DistanceCounter(Vector3 characterPosition, Vector3 enemyPosition)
        {
            float xDelta = Mathf.Abs(characterPosition.x - enemyPosition.x);
            float yDelta = Mathf.Abs(characterPosition.y - enemyPosition.y);
            return Mathf.Sqrt(Mathf.Pow(xDelta, 2) + Mathf.Pow(yDelta, 2));
        }
    }
}