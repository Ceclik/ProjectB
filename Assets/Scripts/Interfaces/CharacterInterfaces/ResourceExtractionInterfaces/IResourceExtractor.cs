using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Interfaces.CharacterInterfaces.ResourceExtractionInterfaces
{
    public interface IResourceExtractor
    {
        public void ExtractResource(Vector3 mousePosition, float maxDistanceForAttack, Character extractingCharacter);
    }
}