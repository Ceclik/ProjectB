using ComponentScripts;
using UnityEngine.UI;

namespace Services.CharacterServices.CharacterStatsScripts
{
    public interface ICharacterHealthHandler
    {
        public void IncreaseHealth(int increaseValue);
        public void DecreaseHealthValue(int decreaseValue);
        public void DecreaseHealthValue(ActiveEntity damageDecreaser);
        public void UpdateHealthBar(Image healthBar);
    }
}