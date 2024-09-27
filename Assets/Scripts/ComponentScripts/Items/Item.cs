using UnityEngine;

namespace ComponentScripts.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected Sprite itemIcon;
        [SerializeField] protected int amount;
        
        public string Name { get; protected set; }
        public int MaxAvailableAmount { get; protected set; }
        public int Amount
        {
            get => amount;
            set => amount = value;
        }
        public Sprite ItemIcon => itemIcon;
        
    }
}