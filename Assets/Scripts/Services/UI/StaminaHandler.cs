using System;
using ComponentScripts.Entities.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI
{
    public class StaminaHandler : MonoBehaviour, IStaminaHandler
    {
        private CharacterStaminaHandler _characterStamina;

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
            throw new System.NotImplementedException();
        }

        public void DecreaseStamina(float decreasingValue)
        {
            _characterStamina.Stamina -= decreasingValue;
            Debug.Log($"Current stamina value: {_characterStamina.Stamina}");
            UpdateStaminaBar();
        }
    }
}