using System;
using Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterStaminaHandler : MonoBehaviour
    {
        //private IStaminaHandler _staminaHandler;
        [SerializeField] [Range(0, 100)] private float stamina;
        [SerializeField] private Image staminaBar;
        [SerializeField] private float increasingStaminaValuePerSecond;
        [SerializeField] private float startStaminaIncreasingDelay;

        public float IncreasingStaminaValuePerSecond => increasingStaminaValuePerSecond;
        public float StartStaminaIncreasingDelay => startStaminaIncreasingDelay;
        public Image StaminaBar => staminaBar;

        public float Stamina
        {
            get => stamina;
            set => stamina = value;
        }

        /*public void Inject(IStaminaHandler staminaHandler)
        {
            _staminaHandler = staminaHandler;
        }*/
        
    }
}