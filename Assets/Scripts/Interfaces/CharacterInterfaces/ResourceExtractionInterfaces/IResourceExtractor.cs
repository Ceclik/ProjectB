using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Services.CharacterServices.ResourcesExtractionScripts
{
    public interface IResourceExtractor
    {
        public void ExtractResource(Vector3 mousePosition, float maxDistanceForAttack, Character extractingCharacter);
    }
}