using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected int baseHealthPoints;
        protected IDespawner Despawner;

        public int ActualHealth { get; set; }

        public int BaseHealth => baseHealthPoints;

        private void Start()
        {
            ActualHealth = baseHealthPoints;
        }
    }
}