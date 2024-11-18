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
        private InventoryOpener _inventoryOpener;

        private void Start()
        {
            _health = GetComponent<Character>();
            _mover = GetComponent<CharacterMover>();
            _attackHandler = GetComponent<CharacterAttackHandler>();
            _resourceExtraction = GetComponent<ResourceExtractionHandler>();
            _inventoryOpener = GetComponent<InventoryOpener>();
        }

        private void FixedUpdate()
        {
            if (_health.ActualHealth <= 0)
            {
                deathPanel.SetActive(true);
                mainHandPanel.SetActive(false);
                secondHandPanel.SetActive(false);

                _mover.enabled = false;
                _attackHandler.enabled = false;
                _resourceExtraction.enabled = false;
                _inventoryOpener.enabled = false;
            }
        }
    }
}