using ComponentScripts.Items.Tools;
using UnityEngine;

namespace DataClasses
{
    public class ToolData : ItemData
    {
        private float _actualDurability;

        public float ActualDurability
        {
            get => _actualDurability;

            set
            {
                if (Mathf.Approximately(value, _actualDurability - 1))
                    _actualDurability = value;
            }
        }

        public ToolData(Tool otherTool) : base(otherTool)
        {
            ActualDurability = otherTool.ActualDurability;
        }
    }
}