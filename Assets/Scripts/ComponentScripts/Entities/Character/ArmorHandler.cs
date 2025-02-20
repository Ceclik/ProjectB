using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ArmorHandler : MonoBehaviour
    {
        private CharacterAnimationsSwitcher _animationsSwitcher;
        private CharacterMover _characterMover;
        private Inventory _inventory;
        private InventoryOpener _inventoryOpener;
        public bool IsUsingShield { get; private set; }

        public float PercentOfBlockingDamage { get; private set; }

        public ShieldData ActualShield { get; private set; }

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _inventory.OnSecondHandUpdate += SetActualShield;
            _inventoryOpener = GetComponent<InventoryOpener>();
            _animationsSwitcher = GetComponent<CharacterAnimationsSwitcher>();
            _characterMover = GetComponent<CharacterMover>();
        }

        private void Update()
        {
            if (_inventory.SecondHand.Value != null && !_inventoryOpener.Inventory.activeSelf)
            {
                if (!IsUsingShield && _inventory.SecondHand.Value.Name == "Shield" && Input.GetKeyDown(KeyCode.Mouse1))
                {
                    IsUsingShield = true;
                    if (!_characterMover.IsMoving)
                        _animationsSwitcher.SetIdleShieldAnimation();
                    Debug.Log("Shield On!");
                }

                if (IsUsingShield && Input.GetKeyUp(KeyCode.Mouse1))
                {
                    IsUsingShield = false;
                    if (!_characterMover.IsMoving)
                        _animationsSwitcher.SetFrontIdleAnimation();
                    Debug.Log("Shield off");
                }
            }
        }

        private void OnDestroy()
        {
            _inventory.OnSecondHandUpdate -= SetActualShield;
        }

        private void SetActualShield(ItemData item)
        {
            if (_inventory.SecondHand.Value is ShieldData)
            {
                ActualShield = (ShieldData)_inventory.SecondHand.Value;
                PercentOfBlockingDamage = ActualShield.PercentOfBlockingDamage;
            }
        }
    }
}