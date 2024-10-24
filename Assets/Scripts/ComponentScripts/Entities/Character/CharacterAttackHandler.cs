using ComponentScripts.Entities.Character.InventoryScripts;
using Services.CharacterServices.CharacterAttackScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterAttackHandler : MonoBehaviour
    {
        [SerializeField] private float maxDistanceForAttack;

        private ICharacterAttackHandler _attackHandler;
        private InventoryOpener _inventoryOpener;

        private void Start()
        {
            _attackHandler = new CharacterAttackService();
            _inventoryOpener = GetComponent<InventoryOpener>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                if (!_inventoryOpener.Inventory.activeSelf)
                {
                    var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                    _attackHandler.Attack(mousePosition, maxDistanceForAttack, GetComponent<Character>());
                }
        }
    }
}