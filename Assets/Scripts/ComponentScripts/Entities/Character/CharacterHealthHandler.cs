using ComponentScripts.Entities.Enemies;
using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterHealthHandler : MonoBehaviour
    {
        public Image HealthBar;
        private ArmorHandler _armorHandler;
        private Character _character;
        private ICharacterDamageReceiver _characterDamageReceiver;
        public ICharacterHealthHandler HealthService { get; private set; }

        private void Start()
        {
            HealthService = gameObject.AddComponent<CharacterHealthHandlerService>();
            _characterDamageReceiver = gameObject.AddComponent<CharacterDamageReceiveService>();
            _armorHandler = GetComponent<ArmorHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                _characterDamageReceiver.ReceiveDamage(enemy.gameObject.GetComponent<ActiveEntity>(), _armorHandler);
                HealthService.UpdateHealthBar(HealthBar);
            }
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }
    }
}