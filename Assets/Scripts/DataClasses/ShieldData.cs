using ComponentScripts.Items.Tools;

namespace DataClasses
{
    public class ShieldData : ToolData
    {
        private float _percentOfBlockingDamage;
        private float _percentOfSlowingCharacter;

        public ShieldData(Shield otherShield) : base(otherShield)
        {
            _percentOfBlockingDamage = otherShield.PercentOfBlockingDamage;
            _percentOfSlowingCharacter = otherShield.PercentOfSlowingCharacter;
        }

        public float PercentOfBlockingDamage
        {
            get => _percentOfBlockingDamage;
            set
            {
                if (value is > 0 and <= 100)
                    _percentOfBlockingDamage = value;
            }
        }

        public float PercentOfSlowingCharacter
        {
            get => _percentOfSlowingCharacter;
            set
            {
                if (value is > 0 and < 100)
                    _percentOfSlowingCharacter = value;
            }
        }
    }
}