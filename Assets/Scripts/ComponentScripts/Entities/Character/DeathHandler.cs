using ComponentScripts.Entities.Character.InventoryScripts;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class DeathHandler : MonoBehaviour
    {
        [Header("UI")] [SerializeField] private GameObject deathPanel;

        [SerializeField] private GameObject mainHandPanel;
        [SerializeField] private GameObject secondHandPanel;

        [Space(10)] [SerializeField] private float itemsDroppingRadius;
        private CharacterAttackHandler _attackHandler;
        private Character _health;
        private CharacterHealthHandler _healthHandler;

        private Inventory _inventory;
        private InventoryOpener _inventoryOpener;

        private IItemsDropper _itemsDropper;
        private CharacterMover _mover;
        private ResourceExtractionHandler _resourceExtraction;

        public bool IsDead { get; private set; }

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _health = GetComponent<Character>();
            _mover = GetComponent<CharacterMover>();
            _attackHandler = GetComponent<CharacterAttackHandler>();
            _resourceExtraction = GetComponent<ResourceExtractionHandler>();
            _inventoryOpener = GetComponent<InventoryOpener>();
            _healthHandler = GetComponent<CharacterHealthHandler>();

            _itemsDropper = secondHandPanel.AddComponent<ItemDropperService>();
        }

        private void FixedUpdate()
        {
            if (_health.ActualHealth <= 0 && !IsDead)
            {
                IsDead = true;

                deathPanel.SetActive(true);
                mainHandPanel.SetActive(false);
                secondHandPanel.SetActive(false);

                _mover.enabled = false;
                _attackHandler.enabled = false;
                _resourceExtraction.enabled = false;
                _inventoryOpener.enabled = false;

                _itemsDropper.DropAllItems(_inventory.Items, transform.position, itemsDroppingRadius);
            }
        }

        public void Reborn()
        {
            IsDead = false;

            _health.ActualHealth = _health.ActualMaxHealth;
            _healthHandler.HealthService.UpdateHealthBar(_healthHandler.HealthBar);

            deathPanel.SetActive(false);
            mainHandPanel.SetActive(true);
            secondHandPanel.SetActive(true);

            _mover.enabled = true;
            _attackHandler.enabled = true;
            _resourceExtraction.enabled = true;
            _inventoryOpener.enabled = true;
        }
    }
}