using System;
using ComponentScripts;
using ComponentScripts.Entities.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public class CharacterHealthHandlerService : MonoBehaviour, ICharacterHealthHandler
    {
        private Character _character;

        private void Start()
        {
            _character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }

        public void IncreaseHealth(int increaseValue)
        {
            throw new NotImplementedException(); //////////////
        }

        public void DecreaseHealthValue(int decreaseValue)
        {
            _character.ActualHealth -= decreaseValue;
        }

        public void DecreaseHealthValue(ActiveEntity damageDecreaser)
        {
            _character.ActualHealth -= damageDecreaser.BaseDamage;
        }

        public void UpdateHealthBar(Image healthBar)
        {
            Debug.Log($"Actual character's health: {_character.ActualHealth}");
            healthBar.fillAmount = (float)_character.ActualHealth * 100 / _character.ActualMaxHealth / 100;
        }
    }
}