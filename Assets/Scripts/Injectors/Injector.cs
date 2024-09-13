using ComponentScripts.Entities.Character;
using Services.CharacterServices.CharacterStatsScripts;
using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private CharacterMover character;

        private CharacterHealthHandler _characterHealthHandler;

        private void Awake()
        {
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMoverService>();
            character.Inject(playerMover);
            
            IStaminaHandler staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            playerMover.Inject(staminaHandler);

            _characterHealthHandler = character.gameObject.GetComponent<CharacterHealthHandler>();
            ICharacterHealthHandler characterHealthHandler = gameObject.AddComponent<CharacterHealthHandlerService>();
            _characterHealthHandler.Inject(characterHealthHandler);
        }
    }
}