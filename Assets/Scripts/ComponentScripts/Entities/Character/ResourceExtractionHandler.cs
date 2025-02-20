using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Interfaces.CharacterInterfaces.ResourceExtractionInterfaces;
using Services.CharacterServices.ResourcesExtractionScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ResourceExtractionHandler : MonoBehaviour
    {
        [SerializeField] private float maxDistanceForExtract;
        private Character _character;
        private Inventory _inventory;
        private InventoryOpener _inventoryOpener;
        private ItemsRemover _itemsRemover;
        private IResourceExtractor _resourceExtractor;

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _resourceExtractor = new ResourceExtractorService();
            _character = GetComponent<Character>();
            _inventoryOpener = GetComponent<InventoryOpener>();
            _itemsRemover = GetComponent<ItemsRemover>();
        }

        private void Update()
        {
            if (!_inventoryOpener.Inventory.activeSelf && Input.GetKeyDown(KeyCode.Mouse0) &&
                _inventory.MainHand.Value is ToolData mainHandTool)
            {
                var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                _resourceExtractor.ExtractResource(mousePosition, maxDistanceForExtract, _character);
            }
        }
    }
}