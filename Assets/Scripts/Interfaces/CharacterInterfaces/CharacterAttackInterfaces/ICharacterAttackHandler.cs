using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Services.CharacterServices.CharacterAttackScripts
{
    public interface ICharacterAttackHandler
    {
        public void Attack(Vector3 mousePosition, float maxDistanceForAttack, Character attackCharacter);
    }
}