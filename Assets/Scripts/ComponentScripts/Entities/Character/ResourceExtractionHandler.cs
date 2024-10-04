using ComponentScripts.Entities.Character.InventoryScripts;
using Services.CharacterServices.ResourcesExtractionScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ResourceExtractionHandler : MonoBehaviour
    {
        [SerializeField] private float maxDistanceForExtract;
        private IResourceExtractor _resourceExtractor;
        private Inventory _inventory;
        private Character _character;

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _resourceExtractor = new ResourceExtractorService();
            _character = GetComponent<Character>();
        }

        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0) && _inventory.MainHand is { Name: "Axe" })
            {
                var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                _resourceExtractor.ExtractResource(mousePosition, maxDistanceForExtract, _character);
            }
        }
        
    }
}