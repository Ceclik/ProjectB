using Interfaces.CharacterInterfaces.MovingInterfaces;
using Services.CharacterServices.CharacterStatsScripts;
using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        private void Awake()
        {
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMoverService>();

            IStaminaHandler staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            playerMover.Inject(staminaHandler);

            ICharacterHealthHandler characterHealthHandlerI = gameObject.AddComponent<CharacterHealthHandlerService>();
        }
    }
}