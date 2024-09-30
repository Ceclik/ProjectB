using ComponentScripts.Items;
using UnityEngine;

namespace DataClasses
{
    public class ItemData
    {
        public ItemData(Item otherItem)
        {
            ItemIcon = otherItem.ItemIcon;
            Name = otherItem.Name;
            MaxAvailableAmount = otherItem.MaxAvailableAmount;
            Amount = otherItem.Amount;
        }

        public ItemData(ItemData otherItem)
        {
            ItemIcon = otherItem.ItemIcon;
            Name = otherItem.Name;
            MaxAvailableAmount = otherItem.MaxAvailableAmount;
            Amount = otherItem.Amount;
        }

        public ItemData()
        {
        }

        public Sprite ItemIcon { get; }
        public string Name { get; protected set; }
        public int MaxAvailableAmount { get; protected set; }
        public int Amount { get; set; }
    }
}