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

        private void Awake()
        {
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMoverService>();
            character.Inject(playerMover);
            
            IStaminaHandler staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            playerMover.Inject(staminaHandler);

            CharacterHealthHandler characterHealthHandler = character.gameObject.GetComponent<CharacterHealthHandler>();
            ICharacterHealthHandler characterHealthHandlerI = gameObject.AddComponent<CharacterHealthHandlerService>();
            
            ICharacterDamageReceiver characterDamageReceiver = new CharacterDamageReceiveService();
            characterHealthHandler.Inject(characterHealthHandlerI, characterDamageReceiver);
            characterDamageReceiver.Inject(characterHealthHandlerI);

            ICharacterAttackHandler characterAttackHandlerI = new CharacterAttackService();
            CharacterAttackHandler characterAttackHandler = character.GetComponent<CharacterAttackHandler>();
            characterAttackHandler.Inject(characterAttackHandlerI);
        }
    }
}