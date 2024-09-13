using ComponentScripts.Entities.Character;
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
        }
    }
}