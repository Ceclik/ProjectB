using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts
{
    public abstract class  Entity : MonoBehaviour
    {
        [SerializeField] protected int baseHealthPoints;
        protected IDespawner Despawner;
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
