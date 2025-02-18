using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Entities.ResourceObjects;
using Services.CharacterServices.CharacterAttackScripts;
using UnityEngine;
using Tree = ComponentScripts.Entities.ResourceObjects.Tree;

namespace Services.CharacterServices.ResourcesExtractionScripts
{
    public class ResourceExtractorService : IResourceExtractor
    {
        public void ExtractResource(Vector3 mousePosition, float maxDistanceForAttack, Character extractingCharacter)
        {
            var characterInventory = extractingCharacter.GetComponent<Inventory>();
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out EntityHealthHandler extractingObject) &&
                    Vector3.Distance(extractingObject.transform.position,
                        extractingCharacter.transform.position) < maxDistanceForAttack)
                    if (hit.collider.TryGetComponent(out ResourceObject resourceObject))
                        if ((resourceObject is Tree && characterInventory.MainHand.Name == "Axe") ||
                            (resourceObject is Rock && characterInventory.MainHand.Name == "Pickaxe"))
                            //(ToolData)characterInventory.MainHand.
                            extractingObject.ReceiveCharacterAttack(extractingCharacter);
        }
    }
}