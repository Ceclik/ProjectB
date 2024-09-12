using UnityEngine.UI;

namespace Services.UI
{
    public interface IStaminaHandler
    {
        public void UpdateStaminaBar();
        public void IncreaseStamina(float increasingValue);
        public void DecreaseStamina(float decreasingValue);
    }
}