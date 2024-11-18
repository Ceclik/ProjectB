using ComponentScripts.Entities.Character.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class DeathHandler : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject deathPanel;
        [SerializeField] private GameObject mainHandPanel;
        [SerializeField] private GameObject secondHandPanel;

        private CharacterMover _mover;
        private CharacterAttackHandler _attackHandler;
        private ResourceExtractionHandler _resourceExtraction;
        private Character _health;
        private CharacterHealthHandler _healthHandler;
        private InventoryOpener _inventoryOpener;
        
        public bool IsDead { get; private set; }

        private void Start()
        {
            _health = GetComponent<Character>();
            _mover = GetComponent<CharacterMover>();
            _attackHandler = GetComponent<CharacterAttackHandler>();
            _resourceExtraction = GetComponent<ResourceExtractionHandler>();
            _inventoryOpener = GetComponent<InventoryOpener>();
            _healthHandler = GetComponent<CharacterHealthHandler>();
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