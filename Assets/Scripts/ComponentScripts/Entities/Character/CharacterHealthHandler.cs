using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterHealthHandler : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        private ArmorHandler _armorHandler;
        private Character _character;
        private ICharacterDamageReceiver _characterDamageReceiver;
        private ICharacterHealthHandler _healthService;

        private void Start()
        {
            _healthService = gameObject.AddComponent<CharacterHealthHandlerService>();
            _characterDamageReceiver = gameObject.AddComponent<CharacterDamageReceiveService>();
            _armorHandler = GetComponent<ArmorHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _characterDamageReceiver.ReceiveDamage(other.gameObject.GetComponent<ActiveEntity>(), _armorHandler);
            _healthService.UpdateHealthBar(healthBar);
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }
    }
}