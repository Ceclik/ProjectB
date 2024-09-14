using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Services.BaseEntityServices
{
    public interface ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, Transform enemiesParent, Vector3 characterPosition,
            float maxDistanceForAttack, Character attackCharacter);
    }
}