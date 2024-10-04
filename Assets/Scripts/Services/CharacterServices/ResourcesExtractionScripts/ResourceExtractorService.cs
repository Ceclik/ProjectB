using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using Services.CharacterServices.CharacterAttackScripts;
using UnityEngine;

namespace Services.CharacterServices.ResourcesExtractionScripts
{
    public class ResourceExtractorService : IResourceExtractor
    {
        public void ExtractResource(Vector3 mousePosition, float maxDistanceForAttack, Character extractingCharacter)
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            CharacterAttackService attackService = new CharacterAttackService();
            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out EntityHealthHandler extractingObject) &&
                    attackService.DistanceCounter(extractingObject.transform.position, extractingCharacter.transform.position) <
                    maxDistanceForAttack)
                    extractingObject.ReceiveCharacterAttack(extractingCharacter);
        }
    }
}