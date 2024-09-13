using Services.BaseEntityServices;
using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterHealthHandler : MonoBehaviour
    {
        private ICharacterHealthHandler _healthService;
        private IDamageReceiver _damageReceiver;
        private Character _character;

        [SerializeField] private Image healthBar;

        public void Inject(ICharacterHealthHandler healthHandler, IDamageReceiver damageReceiver)
        {
            _healthService = healthHandler;
            _damageReceiver = damageReceiver;
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _damageReceiver.ReceiveDamage(other.gameObject.GetComponent<ActiveEntity>());
            _healthService.UpdateHealthBar(healthBar);
        }
    }
}