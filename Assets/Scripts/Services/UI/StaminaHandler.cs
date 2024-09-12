using System;
using System.Collections;
using ComponentScripts.Entities.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI
{
    public class StaminaHandler : MonoBehaviour, IStaminaHandler
    {
        private CharacterStaminaHandler _characterStamina;

        private float _lastStaminaDecreaseTimer;
        private bool _isDecreasing;
        private bool _isIncreasing;

        private void Update()
        {
            if (_isDecreasing)
                _lastStaminaDecreaseTimer += Time.deltaTime;
            
            if(_lastStaminaDecreaseTimer >= _characterStamina.StartStaminaIncreasingDelay)
                IncreaseStamina(_characterStamina.IncreasingStaminaValuePerSecond / 50);
        }

        private void Start()
        {
            _characterStamina = GameObject.Find("Character").GetComponent<CharacterStaminaHandler>(); //TODO remake for multiplayer
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

        private IEnumerator StaminaIncreaser(float increasingValue)
        {
            while (_isIncreasing && _characterStamina.Stamina < 100)
            {
                yield return new WaitForFixedUpdate();
                _characterStamina.Stamina += increasingValue;
                Debug.Log($"Current stamina value: {_characterStamina.Stamina}");
                UpdateStaminaBar();
            }
        }

        public void DecreaseStamina(float decreasingValue)
        {
            _isIncreasing = false;
            if (!_isDecreasing) _isDecreasing = true;
            _lastStaminaDecreaseTimer = 0;
            _characterStamina.Stamina -= decreasingValue;
            Debug.Log($"Current stamina value: {_characterStamina.Stamina}");
            UpdateStaminaBar();
        }
    }
}