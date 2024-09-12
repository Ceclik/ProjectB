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
        
        public Image StaminaBar 
        { 
            get => staminaBar;
            set => staminaBar = value;
        }

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