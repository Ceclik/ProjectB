using Services.BaseItemServices;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected Image itemIcon;
        
        public string Name { get; protected set; }
        public int MaxAvailableAmount { get; protected set; }

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        protected IDropable Dropable;
        [SerializeField] private int _amount;
    }
}