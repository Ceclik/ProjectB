namespace Services.CharacterServices.CharacterStatsScripts
{
    public interface IStaminaHandler
    {
        public void UpdateStaminaBar();
        public void IncreaseStamina(float increasingValue);
        public void DecreaseStamina(float decreasingValue);
    }
}