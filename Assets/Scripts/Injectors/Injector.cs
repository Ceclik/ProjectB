using ComponentScripts.Entities.Character;
using Services.MovingScripts;
using Services.UI;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private CharacterMover character;
        //private CharacterStaminaHandler _characterStamina;

        private void Awake()
        {
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMover>();
            character.Inject(playerMover);
            //_characterStamina = character.gameObject.GetComponent<CharacterStaminaHandler>();
            IStaminaHandler staminaHandler = gameObject.AddComponent<StaminaHandler>();
            playerMover.Inject(staminaHandler);
            //_characterStamina.Inject(staminaHandler);
        }
    }
}