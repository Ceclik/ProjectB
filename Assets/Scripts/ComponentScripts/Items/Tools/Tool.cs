using UnityEngine;

namespace ComponentScripts.Items.Tools
{
    public class Tool : Item
    {
        [SerializeField] private int initialDurability;
        public int InitialDurability => initialDurability;

        public int ActualDurability { get; set; }

        private void Start()
        {
            ActualDurability = InitialDurability;
        }
    }
}