using Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Services.MovingScripts
{
    public interface IPlayerMover
    {
        public void Inject(IStaminaHandler staminaHandler);
        public void MakeTug(Transform characterTransform, KeyCode key, float tugSpeed, float tugDelay, float staminaDecreaseValue);
        public void MakeTug(Transform characterTransform, KeyCode key1, KeyCode key2, float tugSpeed, float tugDelay, float staminaDecreaseValue);
        public void Move(KeyCode key, float movingSpeed, Transform characterTransform, float runSpeed, float staminaDecreaseValue);
        public void Move(KeyCode key1, KeyCode key2 , float movingSpeed, Transform characterTransform, float runSpeed, float staminaDecreaseValue);

        //public delegate void DecreaseStamina(Image , float);
        

    }
}