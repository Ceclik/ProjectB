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
        private ICharacterDamageReceiver _characterDamageReceiver;
        private Character _character;

        [SerializeField] private Image healthBar;

        public void Inject(ICharacterHealthHandler healthHandler, ICharacterDamageReceiver characterDamageReceiver)
        {
            _healthService = healthHandler;
            _characterDamageReceiver = characterDamageReceiver;
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _characterDamageReceiver.ReceiveDamage(other.gameObject.GetComponent<ActiveEntity>());
            _healthService.UpdateHealthBar(healthBar);
        }
    }
}