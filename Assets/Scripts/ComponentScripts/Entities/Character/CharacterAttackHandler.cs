using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterAttackHandler : MonoBehaviour
    {
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private float maxDistanceForAttack;

        private ICharacterAttackHandler _attackHandler;

        public void Inject(ICharacterAttackHandler attackHandler)
        {
            _attackHandler = attackHandler;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                _attackHandler.Attack(mousePosition, maxDistanceForAttack, GetComponent<Character>());
            }
        }
    }
}