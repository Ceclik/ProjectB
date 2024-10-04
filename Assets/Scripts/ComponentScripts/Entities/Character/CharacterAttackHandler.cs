using Services.CharacterServices.CharacterAttackScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterAttackHandler : MonoBehaviour
    {
        [SerializeField] private float maxDistanceForAttack;

        private ICharacterAttackHandler _attackHandler;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                _attackHandler.Attack(mousePosition, maxDistanceForAttack, GetComponent<Character>());
            }
        }

        public void Inject(ICharacterAttackHandler attackHandler)
        {
            _attackHandler = attackHandler;
        }
    }
}