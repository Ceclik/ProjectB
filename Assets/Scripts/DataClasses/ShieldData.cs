using ComponentScripts.Items.Tools;

namespace DataClasses
{
    public class ShieldData : ToolData
    {
        private float _percentOfBlockingDamage;

        public ShieldData(Tool otherTool, float percentOfBlockingDamage) : base(otherTool)
        {
            _percentOfBlockingDamage = percentOfBlockingDamage;
        }

        public ShieldData(Shield otherShield) : base(otherShield)
        {
            _percentOfBlockingDamage = otherShield.PercentOfBlockingDamage;
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
    }
}