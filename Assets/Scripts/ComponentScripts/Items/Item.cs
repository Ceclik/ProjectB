using UnityEngine;

namespace ComponentScripts.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected Sprite itemIcon;
        [SerializeField] protected int amount;
        [SerializeField] protected int maxAvailableAmount;
        [SerializeField] protected string itemName;

        public string Name => itemName;
        public int MaxAvailableAmount => maxAvailableAmount;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public Sprite ItemIcon => itemIcon;
    }
}