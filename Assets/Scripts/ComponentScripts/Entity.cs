using System;
using Interfaces;
using UnityEngine;

namespace ComponentScripts
{
    public abstract class  Entity : MonoBehaviour
    {
        [SerializeField] protected int baseHealthPoints;
        protected IDespawner _despawner;
        private int _actualHealth;

        public int ActualHealth
        {
            get => _actualHealth;
            set => _actualHealth = value;
        }
        
        public int BaseHealth => baseHealthPoints;

        private void Start()
        {
            _actualHealth = baseHealthPoints;
        }
    }
}