using System.Collections;
using ComponentScripts.Entities.Character;
using UnityEngine;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public class StaminaHandlerService : MonoBehaviour, IStaminaHandler
    {
        private CharacterStaminaHandler _characterStamina;
        private bool _isDecreasing;
        private bool _isIncreasing;

        private float _lastStaminaDecreaseTimer;

        private void Start()
        {
            _characterStamina =
                GameObject.FindGameObjectWithTag("Player")
                    .GetComponent<CharacterStaminaHandler>(); //TODO remake for multiplayer
        }

        private void Update()
        {
            if (_isDecreasing)
                _lastStaminaDecreaseTimer += Time.deltaTime;

            if (_lastStaminaDecreaseTimer >= _characterStamina.StartStaminaIncreasingDelay)
                IncreaseStamina(_characterStamina.IncreasingStaminaValuePerSecond / 50);
        }

        public void UpdateStaminaBar()
        {
            _characterStamina.StaminaBar.fillAmount = _characterStamina.Stamina / 100;
        }

        public void IncreaseStamina(float increasingValue)
        {
            _isDecreasing = false;
            _isIncreasing = true;
            StartCoroutine(StaminaIncreaser(increasingValue / 50));
        }

        public void DecreaseStamina(float decreasingValue)
        {
            _isIncreasing = false;
            if (!_isDecreasing) _isDecreasing = true;
            _lastStaminaDecreaseTimer = 0;
            _characterStamina.Stamina -= decreasingValue;
            UpdateStaminaBar();
        }

        private IEnumerator StaminaIncreaser(float increasingValue)
        {
            while (_isIncreasing && _characterStamina.Stamina < 100)
            {
                yield return new WaitForFixedUpdate();
                _characterStamina.Stamina += increasingValue;
                UpdateStaminaBar();
            }
        }
    }
}