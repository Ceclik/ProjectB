using System;
using UnityEngine;

namespace ComponentScripts.Items.Tools
{
    public class Tool : Item
    {
        [SerializeField] private float initialDurability;

        private float _actualDurability;
        public float ActualDurability
        {
            get => _actualDurability;
            set
            {
                if (Mathf.Approximately(value, value - 1))
                    _actualDurability = value;
            }
        }

        private void Start()
        {
            _actualDurability = initialDurability;
        }
    }
}