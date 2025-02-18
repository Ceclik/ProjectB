using ComponentScripts.Items.Tools;

namespace DataClasses
{
    public class ToolData : ItemData
    {
        public int InitialDurability { get; private set; }
        
        public int ActualDurability { get; set; }

        public ToolData(Tool otherTool) : base(otherTool)
        {
            ActualDurability = otherTool.ActualDurability;
            InitialDurability = otherTool.InitialDurability;
        }
    }
}