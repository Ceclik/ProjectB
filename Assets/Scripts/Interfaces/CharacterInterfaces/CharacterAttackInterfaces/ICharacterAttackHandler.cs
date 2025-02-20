using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Interfaces.CharacterInterfaces.CharacterAttackInterfaces
{
    public interface ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, float maxDistanceForAttack, Character attackCharacter);
    }
}