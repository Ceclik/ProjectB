using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterHealthHandler : MonoBehaviour
    {
        private ICharacterHealthHandler _healthService;
        private Character _character;

        [SerializeField] private Image healthBar;

        public void Inject(ICharacterHealthHandler healthHandler)
        {
            _healthService = healthHandler;
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ActiveEntity enemy))
            {
                _healthService.DecreaseHealthValue(enemy);
                _healthService.UpdateHealthBar(healthBar);
            }
        }
    }
}