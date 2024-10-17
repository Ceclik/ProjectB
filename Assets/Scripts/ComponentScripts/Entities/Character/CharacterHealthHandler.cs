using System;
using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterHealthHandler : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        private Character _character;
        private ICharacterDamageReceiver _characterDamageReceiver;
        private ICharacterHealthHandler _healthService;
        private ArmorHandler _armorHandler;

        private void Start()
        {
            _armorHandler = GetComponent<ArmorHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _characterDamageReceiver.ReceiveDamage(other.gameObject.GetComponent<ActiveEntity>(), _armorHandler);
            _healthService.UpdateHealthBar(healthBar);
        }

        public void Inject(ICharacterHealthHandler healthHandler, ICharacterDamageReceiver characterDamageReceiver)
        {
            _healthService = healthHandler;
            _characterDamageReceiver = characterDamageReceiver;
        }

        private void IncreaseHealthForBonusUse()
        {
            //TODO if player use bonus _healthService.IncreaseHealth(); check in Update();
        }
    }
}