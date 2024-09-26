using Services.BaseItemServices;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected Sprite itemIcon;
        
        public string Name { get; protected set; }
        public int MaxAvailableAmount { get; protected set; }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public Sprite ItemIcon => itemIcon;
        
        protected IDropable Dropable;
        [SerializeField] private int amount;

        public Item(Item otherItem)
        {
            itemIcon = otherItem.itemIcon;
            Name = otherItem.Name;
            MaxAvailableAmount = otherItem.MaxAvailableAmount;
            amount = otherItem.amount;
        }
    }
}