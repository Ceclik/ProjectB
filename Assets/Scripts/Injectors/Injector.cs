using ComponentScripts.Entities.Character;
using Services.MovingScripts;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private CharacterMover character;

        private void Awake()
        {
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMover>();
            character.Inject(playerMover);
        }
    }
}