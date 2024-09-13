using ComponentScripts.Entities.Character;
using Services.BaseEntityServices;
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
            
            IDamageReceiver damageReceiver = new CharacterDamageReceiveService();
            _characterHealthHandler.Inject(characterHealthHandler, damageReceiver);
            damageReceiver.Inject(characterHealthHandler);
        }
    }
}